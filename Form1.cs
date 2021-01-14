using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SearchOption = System.IO.SearchOption;

namespace FileMover {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private bool exitTask = false;

        /*
         * 元フォルダ選択ボタン 
         */
        private void button1_Click(object sender, EventArgs e) {
            var dialog = new FolderSelectDialog();
            dialog.Title = label1.Text;
            if (dialog.ShowDialog() == DialogResult.OK) {
                textBox1.Text = dialog.Path;
            }
        }

        /*
         * 対象フォルダ選択ボタン 
         */
        private void button2_Click(object sender, EventArgs e) {
            var dialog = new FolderSelectDialog();
            dialog.Title = label2.Text;
            if (dialog.ShowDialog() == DialogResult.OK) {
                textBox2.Text = dialog.Path;
            }
        }

        /*
         * 開始ボタン
         */
        private void start_Click(object sender, EventArgs e) {
            if (this.start.Text.Equals("停止")) {
                this.exitTask = true;
                this.start.Enabled = false;
                return;
            }
            // テキストボックスに何も入力されていない場合
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0) {
                MessageBox.Show("フォルダを選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            miniConsole.ResetText();

            var temp = new List<String>();
            if (!this.autoTitle.Checked) {
                // タイトルから自動的にフォルダ名を生成

                // ファイルを取得
                var files = Directory.GetFiles(textBox1.Text, "*");

                var pattern = "([0-9]{4})年(0[1-9]|1[0-2])月(0[1-9]|[12][0-9]|3[01])日([0-9]{2})時([0-9]{2})分([0-9]{2})秒";

                // 2021年01月01日23時00分00秒-[新]タイトル 第1話「」
                foreach (var name in files) {
                    var match = Regex.Match(this.getName(name).Split('-')[0], pattern);
                    if (!match.Success) {
                        continue;
                    }

                    var title = Regex.Replace(name, pattern + "-", "");
                    var _chars = new String[] { "第", "#", "STAGE" };

                    foreach (var _char in _chars) {
                        if (title.Contains(_char)) {
                            title = title.Split(new String[] { _char }, StringSplitOptions.RemoveEmptyEntries)[0];
                        }
                    }

                    // [新] とか [字] を消す
                    title = Regex.Replace(title, "\\[.\\]", "");
                    title = title.Replace("<アニメギルド>", "").Replace("アニメ", "");
                    title = title.Replace(".mp4", "").Replace(".ts", "").Replace(".m2ts", "");
                    title = title.Split('\\')[title.Split('\\').Length - 1].Trim();

                    if (!temp.Contains(title)) {
                        temp.Add(title);
                    }
                }
            } else {
                // 出力先フォルダから全てのフォルダを取得
                var files = Directory.GetDirectories(textBox2.Text, "*", SearchOption.AllDirectories);

                // 出力先フォルダに存在するフォルダを temp に追加
                foreach (var folder in files) {
                    var name = folder.Replace(textBox2.Text, "");
                    if (name.StartsWith("\\") && name.Length >= 2) {
                        name = name.Substring(1);
                    }
                    if (name.Contains("\\")) {
                        name = name.Split('\\')[0];
                    }

                    if (!temp.Contains(name)) {
                        temp.Add(name);
                    }
                }
            }

            // temp を長さ順に並び替え
            var folders = temp.OrderByDescending(x => x.Length);

            // <元ファイル名, 出力先ファイル名> の形で保存
            var maps = new Dictionary<String, String>();

            foreach (var folder in folders) {
                // 元フォルダのファイルをスキャン
                foreach (var name in Directory.GetFiles(textBox1.Text, "*")) {
                    // ファイル名が .ts, .mp4 出ない場合スキップ
                    if (!(name.EndsWith(".ts") || name.EndsWith(".mp4"))) {
                        continue;
                    }
                    // 名前にフォルダ名が含まれていない場合スキップ
                    if (!name.Contains(folder)) {
                        continue;
                    }

                    // 小フォルダに保存オプションを判別して出力先を変更
                    var output = folder;
                    if (tsBox.Checked && name.EndsWith(".ts")) {
                        output += "\\ts";
                    } else if (mp4Box.Checked && name.EndsWith(".mp4")) {
                        output += "\\mp4";
                    }

                    // 出力先フォルダを再設定
                    if (textBox2.Text.EndsWith("\\")) {
                        output = textBox2.Text + output;
                    } else {
                        output = textBox2.Text + "\\" + output;
                    }
                    output += "\\";

                    // コピーデータを maps に追加
                    if (!maps.ContainsKey(name)) {
                        if (!File.Exists(output)) {
                            Directory.CreateDirectory(output);
                        }

                        maps.Add(name, output);
                    }
                }
            }
            int max = maps.Count;

            // プログレスバーの最大値を設定
            progressBar1.Maximum = max;

            ThreadPool.runAsync(() => {
                int ended = 0;

                this.Invoke((MethodInvoker) delegate {
                    this.start.Text = "停止";
                });

                var directories = new List<String>();
                foreach (var map in maps) {
                    if (this.exitTask) {
                        break;
                    }

                    if (!directories.Contains(map.Value)) {
                        directories.Add(map.Value);
                    }

                    var name = map.Key;
                    var filename = name.Split('\\')[name.Split('\\').Length - 1];
                    var output = map.Value + filename;

                    // 進歩率計算
                    double dMax = (double) max;
                    double dEnded = (double) ended;
                    double percent = dEnded / dMax * 100;
                    String strPercent = String.Format("{0:0}", percent) + "%";

                    this.Invoke((MethodInvoker) delegate {
                        progressFileLabel.Text = strPercent + " " + filename;
                    });

                    if (File.Exists(output)) {
                        ended++;
                        this.Invoke((MethodInvoker) delegate {
                            miniConsole.AppendText("コピー済み: " + name.Replace(textBox1.Text, "...") + "\n\n");
                        });
                        continue;
                    }

                    // rollback.csv から既にコピー済みのファイルを取得しコピー済みならばスキップ
                    var csv = map.Value + "rollback.csv";
                    if (File.Exists(csv)) {
                        var parser = new TextFieldParser(csv, Encoding.UTF8);
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters("|");

                        var rows = new List<String[]>();
                        var _continue = false;
                        String lastRow = null;
                        while (!parser.EndOfData) {
                            String[] row = parser.ReadFields();
                            if (filename.Equals(this.getName(row[0]))) {
                                _continue = true;
                                lastRow = row[0];
                                break;
                            }
                        }
                        parser.Close();

                        if (_continue) {
                            ended++;
                            this.Invoke((MethodInvoker) delegate {
                                miniConsole.AppendText("コピー済み: " + lastRow + "\n\n");
                            });
                            continue;
                        }
                    }

                    this.Invoke((MethodInvoker) delegate {
                        miniConsole.AppendText(name.Replace(textBox1.Text, "...") + "\n");
                    });

                    // ファイルコピー
                    File.Copy(name, output);

                    ended++;

                    // プログレスバーを更新
                    this.Invoke((MethodInvoker) delegate {
                        miniConsole.AppendText("->" + output.Replace(textBox2.Text, "...") + "\n\n");
                        progressBar1.Value = ended;
                    });

                    // MessageBox.Show(output, "処理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (this.exitFixFile.Checked) {
                    foreach (var directory in directories) {
                        this.Invoke((MethodInvoker) delegate {
                            progressFileLabel.Text = "FixFile を実行中: " + directory;
                        });
                        Process process = new Process();
                        process.StartInfo.FileName = "fixfile";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.WorkingDirectory = directory;
                        process.Start();
                    }
                }

                this.Invoke((MethodInvoker) delegate {
                    progressBar1.Value = 0;
                    progressFileLabel.Text = "待機中";
                    this.start.Text = "開始";
                    if (this.exitTask) {
                        MessageBox.Show("処理を停止しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("すべてのファイルをコピーしました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.start.Enabled = true;
                    this.exitTask = false;
                });
            });

            // Console.WriteLine(value);
            // MessageBox.Show(value, "処理", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /*
         * 処理プログレスバー
         */
        private void progressBar1_Click(object sender, EventArgs e) {
        }

        /*
         * 
         */
        private void progressFileLabel_Click(object sender, EventArgs e) {
        }

        public String getName(String file) {
            String name;
            if (file.StartsWith(".\\")) {
                name = file.Substring(2);
            } else {
                name = file;
            }
            return name;
        }

    }

}
