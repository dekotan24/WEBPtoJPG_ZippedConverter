using System.Drawing.Imaging;
using System.IO.Compression;
using System.Text;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;

namespace WEBPtoJPG_ZippedConverter
{
	public partial class Main : Form
	{
		public static readonly string AppName = "WebpToJpg ZippedConverter";
		public static readonly string AppVer = "1.2.0";
		private string randomKey = string.Empty;
		public string message = string.Empty;

		public Main()
		{
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			logText.Clear();
			logText.AppendText(AppName + " Ver." + AppVer);
			versionLabel.Text = "Ver." + AppVer;

			encodingList.SelectedIndex = 0;

			generateNewRandomKey();

			workFolderPathText.Text = Directory.GetCurrentDirectory() + "\\";
		}

		private void importZipFileBrowseButton_Click(object sender, EventArgs e)
		{
			openFileDialog1 = new OpenFileDialog();
			openFileDialog1.Title = "変換元ZIPファイルを選択";
			openFileDialog1.Filter = "ZIPファイル(*.zip)|*.zip";
			openFileDialog1.FileName = "";
			if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
			{
				importZipFilePathText.Text = openFileDialog1.FileName;
				autoComplete(openFileDialog1.FileName);
			}
			return;
		}

		private void importZipDirectoryBrowseButton_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1 = new FolderBrowserDialog();
			folderBrowserDialog1.Description = "変換元ZIPファイルが含まれるフォルダを選択";
			if (folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
			{
				importZipDirectoryPathText.Text = folderBrowserDialog1.SelectedPath;
				autoComplete(folderBrowserDialog1.SelectedPath);
			}
			return;
		}

		private void workFolderBrowseText_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1 = new FolderBrowserDialog();
			folderBrowserDialog1.Description = "作業フォルダを選択";
			if (folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
			{
				workFolderPathText.Text = folderBrowserDialog1.SelectedPath;
			}
			return;
		}

		private void exportZipFileBrowseButton_Click(object sender, EventArgs e)
		{
			if (importZipFileRadio.Checked)
			{
				saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.Title = "変換後ZIPファイル保存先を選択";
				saveFileDialog1.Filter = "ZIPファイル(*.zip)|*.zip";
				saveFileDialog1.FileName = "";
				if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
				{
					exportZipPathText.Text = saveFileDialog1.FileName;
				}
			}
			else
			{
				folderBrowserDialog1 = new FolderBrowserDialog();
				folderBrowserDialog1.Description = "変換後のZIPファイルを保存するフォルダを選択";
				if (folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
				{
					workFolderPathText.Text = folderBrowserDialog1.SelectedPath;
				}
			}
			return;
		}

		private void executeButton_Click(object sender, EventArgs e)
		{
			if (importZipFilePathText.Text.Trim().Length == 0 && importZipFileRadio.Checked)
			{
				MessageBox.Show("参照元ZIPファイルは必須です。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				importZipFilePathText.Focus();
				return;
			}
			if (importZipDirectoryPathText.Text.Trim().Length == 0 && importZipDirectoryRadio.Checked)
			{
				MessageBox.Show("参照元ZIPディレクトリは必須です。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				importZipDirectoryPathText.Focus();
				return;
			}
			if (workFolderPathText.Text.Trim().Length == 0)
			{
				MessageBox.Show("ワークフォルダは必須です。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				workFolderPathText.Focus();
				return;
			}
			if (exportZipPathText.Text.Trim().Length == 0)
			{
				MessageBox.Show("変換後ZIPファイルは必須です。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				exportZipPathText.Focus();
				return;
			}
			if (File.Exists(exportZipPathText.Text.Trim()))
			{
				MessageBox.Show("変換後ZIPファイルパスは既に存在しています。\n存在しないファイル名を指定してください。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				exportZipPathText.Focus();
				return;
			}
			if (!(Path.GetExtension(importZipFilePathText.Text.Trim()).ToUpper() == ".ZIP") && importZipFileRadio.Checked)
			{
				MessageBox.Show("参照元ZIPファイルパスはZIPファイルではありません。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				importZipFilePathText.Focus();
				return;
			}
			if (!(Path.GetExtension(exportZipPathText.Text.Trim()).ToUpper() == ".ZIP") && importZipFileRadio.Checked)
			{
				MessageBox.Show("変換後ZIPファイルパスはZIPファイルではありません。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				exportZipPathText.Focus();
				return;
			}

			string workKey = randomKey;
			bool fileMode = importZipFileRadio.Checked;
			string importPath = fileMode ? importZipFilePathText.Text.Trim() : importZipDirectoryPathText.Text.Trim();
			string workDir = Path.Combine(workFolderPathText.Text.Trim(), workKey);
			string exportPath = exportZipPathText.Text.Trim();
			bool delAfterConvertFlg = oldFileDelCheck.Checked;
			bool renameFlg = renameCheck.Checked;
			int imgQuality = (int)qualityText.Value;

			logText.Clear();
			logText.AppendText(AppName + " Ver." + AppVer);
			addInfoMessage("処理開始！処理は別スレッドで実行されています。ダイアログが表示されるまでしばらくお待ち下さい。\n対象ファイル：" + importPath + "\nワークキー：" + workKey);

			Thread t = new Thread(new ThreadStart(() =>
			{
				Exec execForm = new Exec(importPath, workDir, exportPath, delAfterConvertFlg, renameFlg, imgQuality, workKey, fileMode);
			}));
			t.Start();

			generateNewRandomKey();

			importZipFilePathText.Text = exportZipPathText.Text = importZipDirectoryPathText.Text = string.Empty;
		}

		public void addInfoMessage(string message)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("\n[INFO] ").Append(message).Append(" (").Append(DateTime.Now).Append(")");
			message = sb.ToString();

			if (this.InvokeRequired)
			{
				this.Invoke(new Action(this.writeLog));
			}
			else
			{
				logText.AppendText(message);
			}
			return;
		}

		private void writeLog()
		{
			logText.AppendText(message);
			return;
		}

		private void autoComplete(string basePath)
		{
			string fullPath = string.Empty;
			if (!Directory.Exists(basePath))
			{
				// ファイルの場合
				fullPath = Path.Combine(Path.GetDirectoryName(basePath), Path.GetFileNameWithoutExtension(basePath) + "_convert.zip");
			}
			else
			{
				// フォルダの場合
				fullPath = Path.Combine(Path.GetDirectoryName(basePath), "convert");
			}
			exportZipPathText.Text = fullPath;
		}

		private void AddItem_DragDrop(object sender, DragEventArgs e)
		{
			// DataFormats.FileDropを与えて、GetDataPresent()メソッドを呼び出す。
			var dropTarget = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			// GetDataにより取得したString型の配列から要素を取り出す。
			var targetFile = dropTarget[0];

			if (File.Exists(targetFile))
			{
				importZipFilePathText.Text = targetFile;
				importZipDirectoryPathText.Text = string.Empty;
				importZipFileRadio.Checked = true;
			}
			else if (Directory.Exists(targetFile))
			{
				importZipFilePathText.Text = string.Empty;
				importZipDirectoryPathText.Text = targetFile;
				importZipDirectoryRadio.Checked = true;
			}
			else
			{
				return;
			}
			autoComplete(targetFile);
		}

		private void AddItem_DragEnter(object sender, DragEventArgs e)
		{
			// マウスポインター形状変更
			//
			// DragDropEffects
			//  Copy  :データがドロップ先にコピーされようとしている状態
			//  Move  :データがドロップ先に移動されようとしている状態
			//  Scroll:データによってドロップ先でスクロールが開始されようとしている状態、あるいは現在スクロール中である状態
			//  All   :上の3つを組み合わせたもの
			//  Link  :データのリンクがドロップ先に作成されようとしている状態
			//  None  :いかなるデータもドロップ先が受け付けようとしない状態

			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void oldFileDelCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (oldFileDelCheck.Checked)
			{
				renameCheck.Enabled = true;
				if (renameCheck.Checked)
				{
					groupBox2.Enabled = false;
				}
				else
				{
					groupBox2.Enabled = true;
				}
			}
			else
			{
				renameCheck.Enabled = false;
				groupBox2.Enabled = true;
			}
		}

		private void generateNewRandomKey()
		{
			// ランダムワークキー作成
			var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".EnumerateRunes().ToArray();
			var builder = new System.Text.StringBuilder();
			Random r = new Random();
			for (int i = 0; i < 5; i++)
			{
				builder.Append(chars[r.Next(chars.Length)]);
			}
			randomKey = builder.ToString();
		}

		private void importZipFileRadio_CheckedChanged(object sender, EventArgs e)
		{
			importTypeRadioChanged(true);
		}

		private void importZipDirectoryRadio_CheckedChanged(object sender, EventArgs e)
		{
			importTypeRadioChanged(false);
		}

		private void importTypeRadioChanged(bool fileMode)
		{
			importZipFilePathText.Enabled = fileMode;
			importZipFileBrowseButton.Enabled = fileMode;
			importZipDirectoryPathText.Enabled = !fileMode;
			importZipDirectoryBrowseButton.Enabled = !fileMode;
		}

		private void renameCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (renameCheck.Checked)
			{
				groupBox2.Enabled = false;
			}
			else
			{
				groupBox2.Enabled = true;
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("【注意！】\n・本ツールを使用すると、ZIPファイル内のディレクトリ構造が壊れます。\n（全てのファイルがルートパスに圧縮されます）\n\n・上記の仕様上、同じ名前のファイルが被ると予期せぬ不具合が発生する可能性が高いです。\n\n・文字コードはShift-JISのみ対応しています。\nエンコードが違うと、解凍時にエラーになる場合があります。\nShift-JISで再圧縮してください。\n\nいかなる損害・損失なども一切の責任を負いません。\n自己責任でご利用ください。", "リンクに見せかけてダイアログ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}