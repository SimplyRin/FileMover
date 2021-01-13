# FileMover
EPGStation で録画したファイルをアニメタイトル毎のフォルダに自動でコピーするソフト

FixFile の rollback.csv を使用しファイル名を整えている状態でも、コピー済みのファイルはスキップしてくれます。

録画フォルダを Windows のエクスプローラーで見れる環境([Samba](https://qiita.com/k-Mata/items/8bee9e02e74565b6c147) など)を整えている状態が必要です。

# オプション説明
- "存在するフォルダのみにコピー"
  - 新しいタイトルフォルダーを作成せず、出力先フォルダ名に一致するファイルのみコピーします。

- "終了時 FixFile を実行"
  - システム環境変数に FixFile.exe が通っている場合のみ動作します。
  - すべてのファイルのコピーが終わったとき自動的に FixFile を実行します。
    - コンソールが大量に出てくるのでタスクバーから一括終了してください。

- "子フォルダを作成"
  - チェックを付けたファイルタイプをコピーしたとき以下のような形でコピーしてくれます。
  - .mp4: 出力先\\タイトル\\ts\\ファイル名.ts
  - .ts: 出力先\\タイトル\\mp4\\ファイル名.mp4

# 参考ページ
・[「まともな」フォルダ選択ダイアログ（Vista以降) - 簡単に FileOpenDialog を実装してみる](https://qiita.com/otagaisama-1/items/b0804b9d6d37d82950f7)

# スクリーンショット
![progress.png](https://github.com/SimplyRin/FileMover/blob/main/gif/progress.png?raw=true)

![main.png](https://github.com/SimplyRin/FileMover/blob/main/gif/progress.png?raw=true)
