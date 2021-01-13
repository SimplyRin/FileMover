namespace FileMover {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressFileLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tsBox = new System.Windows.Forms.CheckBox();
            this.mp4Box = new System.Windows.Forms.CheckBox();
            this.exitFixFile = new System.Windows.Forms.CheckBox();
            this.autoTitle = new System.Windows.Forms.CheckBox();
            this.miniConsole = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = ".ts と .mp4 ファイルが存在する録画フォルダ：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 19);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "選択";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(485, 108);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(52, 23);
            this.start.TabIndex = 6;
            this.start.Text = "開始";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 83);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(522, 19);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(496, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "選択";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(280, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(257, 19);
            this.textBox2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "録画ファイルの出力先フォルダ：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "処理中のファイル:";
            // 
            // progressFileLabel
            // 
            this.progressFileLabel.AutoSize = true;
            this.progressFileLabel.BackColor = System.Drawing.Color.Transparent;
            this.progressFileLabel.Location = new System.Drawing.Point(100, 65);
            this.progressFileLabel.Name = "progressFileLabel";
            this.progressFileLabel.Size = new System.Drawing.Size(41, 12);
            this.progressFileLabel.TabIndex = 12;
            this.progressFileLabel.Text = "待機中";
            this.progressFileLabel.Click += new System.EventHandler(this.progressFileLabel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "子フォルダを作成:";
            // 
            // tsBox
            // 
            this.tsBox.AutoSize = true;
            this.tsBox.Location = new System.Drawing.Point(397, 112);
            this.tsBox.Name = "tsBox";
            this.tsBox.Size = new System.Drawing.Size(36, 16);
            this.tsBox.TabIndex = 16;
            this.tsBox.Text = ".ts";
            this.tsBox.UseVisualStyleBackColor = true;
            // 
            // mp4Box
            // 
            this.mp4Box.AutoSize = true;
            this.mp4Box.Location = new System.Drawing.Point(439, 112);
            this.mp4Box.Name = "mp4Box";
            this.mp4Box.Size = new System.Drawing.Size(47, 16);
            this.mp4Box.TabIndex = 17;
            this.mp4Box.Text = ".mp4";
            this.mp4Box.UseVisualStyleBackColor = true;
            // 
            // exitFixFile
            // 
            this.exitFixFile.AutoSize = true;
            this.exitFixFile.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.exitFixFile.Location = new System.Drawing.Point(165, 112);
            this.exitFixFile.Name = "exitFixFile";
            this.exitFixFile.Size = new System.Drawing.Size(136, 16);
            this.exitFixFile.TabIndex = 18;
            this.exitFixFile.Text = "終了時 FixFile を実行";
            this.exitFixFile.UseVisualStyleBackColor = true;
            // 
            // autoTitle
            // 
            this.autoTitle.AutoSize = true;
            this.autoTitle.Location = new System.Drawing.Point(15, 112);
            this.autoTitle.Name = "autoTitle";
            this.autoTitle.Size = new System.Drawing.Size(150, 16);
            this.autoTitle.TabIndex = 19;
            this.autoTitle.Text = "存在するﾌｫﾙﾀﾞにのみｺﾋﾟｰ";
            this.autoTitle.UseVisualStyleBackColor = true;
            // 
            // miniConsole
            // 
            this.miniConsole.Location = new System.Drawing.Point(15, 141);
            this.miniConsole.Name = "miniConsole";
            this.miniConsole.ReadOnly = true;
            this.miniConsole.Size = new System.Drawing.Size(522, 162);
            this.miniConsole.TabIndex = 20;
            this.miniConsole.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 314);
            this.Controls.Add(this.miniConsole);
            this.Controls.Add(this.autoTitle);
            this.Controls.Add(this.exitFixFile);
            this.Controls.Add(this.mp4Box);
            this.Controls.Add(this.tsBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressFileLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.start);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "FileMover";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label progressFileLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox tsBox;
        private System.Windows.Forms.CheckBox mp4Box;
        private System.Windows.Forms.CheckBox exitFixFile;
        private System.Windows.Forms.CheckBox autoTitle;
        private System.Windows.Forms.RichTextBox miniConsole;
    }
}

