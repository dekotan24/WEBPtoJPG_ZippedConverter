using System.Drawing.Imaging;
using System.IO.Compression;
using System.Text;
using ImageProcessor.Plugins.WebP.Imaging.Formats;

namespace WEBPtoJPG_ZippedConverter
{
	public partial class Main : Form
	{
		private readonly string AppName = "WebpToJpg ZippedConverter";
		private string randomKey = string.Empty;
		public string message = string.Empty;

		public Main()
		{
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			logText.Clear();
			logText.AppendText(AppName + " Ver." + ProductVersion);
			versionLabel.Text = "Ver." + ProductVersion;

			// ランダムワークキー作成
			var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".EnumerateRunes().ToArray();
			var builder = new System.Text.StringBuilder();
			Random r = new Random();
			for (int i = 0; i < 5; i++)
			{
				builder.Append(chars[r.Next(chars.Length)]);
			}
			randomKey = builder.ToString();

			workFolderPathText.Text = Directory.GetCurrentDirectory() + "\\" + randomKey + "\\";
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

		private void workFolderBrowseText_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1 = new FolderBrowserDialog();
			folderBrowserDialog1.Description = "作業フォルダを選択";
			if (folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
			{
				workFolderPathText.Text = ((folderBrowserDialog1.SelectedPath).EndsWith("\\") ? folderBrowserDialog1.SelectedPath : folderBrowserDialog1.SelectedPath + "\\") + randomKey + "\\";
			}
			return;
		}

		private void exportZipFileBrowseButton_Click(object sender, EventArgs e)
		{
			saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Title = "変換後ZIPファイル保存先を選択";
			saveFileDialog1.Filter = "ZIPファイル(*.zip)|*.zip";
			saveFileDialog1.FileName = "";
			if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
			{
				exportZipFilePathText.Text = saveFileDialog1.FileName;
			}
			return;
		}

		private void executeButton_Click(object sender, EventArgs e)
		{
			if (importZipFilePathText.Text.Trim().Length == 0)
			{
				MessageBox.Show("参照元ZIPファイルは必須です。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				importZipFilePathText.Focus();
				return;
			}
			if (workFolderPathText.Text.Trim().Length == 0)
			{
				MessageBox.Show("ワークフォルダは必須です。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				workFolderPathText.Focus();
				return;
			}
			if (exportZipFilePathText.Text.Trim().Length == 0)
			{
				MessageBox.Show("変換後ZIPファイルは必須です。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				exportZipFilePathText.Focus();
				return;
			}
			if (File.Exists(exportZipFilePathText.Text.Trim()))
			{
				MessageBox.Show("変換後ZIPファイルパスは既に存在しています。\n存在しないファイル名を指定してください。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				exportZipFilePathText.Focus();
				return;
			}
			if (!(Path.GetExtension(importZipFilePathText.Text.Trim()).ToUpper() == ".ZIP"))
			{
				MessageBox.Show("参照元ZIPファイルパスはZIPファイルではありません。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				importZipFilePathText.Focus();
				return;
			}
			if (!(Path.GetExtension(exportZipFilePathText.Text.Trim()).ToUpper() == ".ZIP"))
			{
				MessageBox.Show("変換後ZIPファイルパスはZIPファイルではありません。", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				exportZipFilePathText.Focus();
				return;
			}

			string importPath = importZipFilePathText.Text.Trim();
			string workDir = workFolderPathText.Text.Trim();
			string exportPath = exportZipFilePathText.Text.Trim();

			logText.Clear();
			logText.AppendText(AppName + " Ver." + ProductVersion);
			addInfoMessage("処理開始！\n処理は別スレッドで実行されています。ダイアログが表示されるまでしばらくお待ち下さい。");

			Thread t = new Thread(new ThreadStart(() =>
			{
				convert(importPath, workDir, exportPath);
			}));
			t.Start();

			importZipFilePathText.Text = exportZipFilePathText.Text = string.Empty;
		}

		private void convert(string importPath, string workDirectory, string exportPath)
		{
			string baseFilePath = importPath;
			string workDir = (workDirectory).EndsWith("\\") ? workDirectory.Trim() : workDirectory.Trim() + "\\";
			string saveFilePath = exportPath;

			// ワークディレクトリ内ファイルクリーン
			addInfoMessage("ワークディレクトリ内ファイルクリーンを開始");
			cleanWorkDir(workDir);

			// ZIPファイル抽出
			addInfoMessage("ZIPファイルの抽出を開始");

			if (!UnZip(baseFilePath, workDir))
			{
				addInfoMessage("処理を中断しました。");
				return;
			}

			// ファイル変換
			addInfoMessage("ファイルの変換を開始");
			if (!convertToJpg(workDir))
			{
				addInfoMessage("処理を中断しました。");
				return;
			}

			// 再圧縮
			addInfoMessage("ファイルの再圧縮を開始");
			if (!compress(workDir + "convert", saveFilePath))
			{
				addInfoMessage("処理を中断しました。");
				return;
			}

			// ワークディレクトリ内ファイルクリーン
			addInfoMessage("ワークディレクトリ内ファイルクリーンを開始");
			cleanWorkDir(workDir);

			// 完了処理
			addInfoMessage("完了！\n保存先：" + saveFilePath);
			MessageBox.Show("処理完了！\n保存先\n[" + saveFilePath + "]", AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

			return;
		}

		private bool UnZip(string unZipFilePath, string workDir)
		{
			bool result = true;

			// 展開元ファイル存在チェック
			if (!File.Exists(unZipFilePath))
			{
				addErrorMessage("ファイルが見つかりません", unZipFilePath);
				return false;
			}

			// 作業ディレクトリ存在チェック
			if (!Directory.Exists(workDir))
			{
				// 存在しない場合、フォルダ作成
				try
				{
					Directory.CreateDirectory(workDir);
				}
				catch (Exception ex)
				{
					addErrorMessage(ex.Message, workDir);
					return false;
				}
			}

			try
			{
				ZipFile.ExtractToDirectory(unZipFilePath, workDir);
			}
			catch (Exception ex)
			{
				addErrorMessage(ex.Message, unZipFilePath, workDir);
				cleanWorkDir(workDir);
				return false;
			}
			return result;
		}

		private bool convertToJpg(string workDir)
		{
			bool result = true;
			if (File.Exists(workDir + "*.webp"))
			{
				addErrorMessage("webpファイルがありません", workDir);
				cleanWorkDir(workDir);
				return false;
			}

			// コンバートフォルダ作成
			if (!Directory.Exists(workDir + "convert"))
			{
				try
				{
					Directory.CreateDirectory(workDir + "convert");
				}
				catch (Exception ex)
				{
					addErrorMessage(ex.Message, workDir + "convert");
					cleanWorkDir(workDir);
					return false;
				}
			}

			// 変換処理
			foreach (string file in Directory.GetFiles(workDir, "*.webp", SearchOption.TopDirectoryOnly))
			{
				string fileName = Path.GetFileNameWithoutExtension(file);
				string outputPath = workDir + "convert\\" + fileName + ".jpg";

				try
				{
					// 変換
					Save(file, outputPath, ImageFormat.Jpeg);
				}
				catch (Exception ex)
				{
					addErrorMessage(ex.Message, file);
					cleanWorkDir(workDir);
					return false;
				}
			}
			return result;
		}

		private bool compress(string workDir, string targetPath)
		{
			bool result = true;
			try
			{
				ZipFile.CreateFromDirectory(workDir, targetPath);
			}
			catch (Exception ex)
			{
				addErrorMessage(ex.Message, workDir, targetPath);
				cleanWorkDir(workDir);
				return false;
			}
			return result;
		}

		public void addErrorMessage(string message, string path, string appendMessage = "")
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("\n[ERROR] ").Append(message).Append(" [").Append(path).Append("] ").Append(appendMessage).Append(" (").Append(DateTime.Now).Append(")");
			MessageBox.Show(sb.ToString(), AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			/*
			message = sb.ToString();

			if (this.InvokeRequired)
			{
				this.Invoke(new Action(this.writeLog));
			}
			else
			{
				logText.AppendText(message);
			}
			*/
			return;
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

		private bool cleanWorkDir(string workDir)
		{
			bool result = true;
			try
			{
				if (Directory.Exists(workDir))
				{
					Directory.Delete(workDir, true);
				}
			}
			catch (Exception ex)
			{
				addErrorMessage(ex.Message, workDir);
				return false;
			}
			return result;
		}

		private void writeLog()
		{
			logText.AppendText(message);
			return;
		}

		private void Save(string inputFile, string outputFile, ImageFormat format)
		{
			var wf = new WebPFormat();
			var stream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
			var image = (Bitmap)wf.Load(stream);
			image.Save(outputFile, format);
			stream.Close();
		}


		private void autoComplete(string basePath)
		{
			string fullPath = ((Path.GetDirectoryName(basePath)).EndsWith("\\") ? Path.GetDirectoryName(basePath) : Path.GetDirectoryName(basePath) + "\\") + Path.GetFileNameWithoutExtension(basePath) + "_convert.zip";
			exportZipFilePathText.Text = fullPath;
		}

		private void AddItem_DragDrop(object sender, DragEventArgs e)
		{
			// DataFormats.FileDropを与えて、GetDataPresent()メソッドを呼び出す。
			var dropTarget = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			// GetDataにより取得したString型の配列から要素を取り出す。
			var targetFile = dropTarget[0];

			importZipFilePathText.Text = targetFile;
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
	}
}