using System.Drawing.Imaging;
using System.IO.Compression;
using System.Text;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;

namespace WEBPtoJPG_ZippedConverter
{
	public partial class Exec : Form
	{
		private string[] targetFiles = new string[999];
		private int maxCounter = 1;

		public Exec(string importPath, string workDirectory, string exportPath, bool delFlg, bool renameFlg, int quality, string workKey, bool fileMode)
		{
			InitializeComponent();
			Show();
			Application.DoEvents();

			statProgress.Value = 0;
			statProgress.Maximum = 6;   // Phase6
			ttlProgress.Value = 0;
			ttlProgress.Maximum = 0;
			wkKey.Text = workKey;

			string baseFilePath = importPath;
			string workDir = Path.Combine(workDirectory.Trim());
			int currentCount = 0;

			if (!fileMode)
			{
				maxCounter = getTargetFilesCounter(baseFilePath);
			}
			else
			{
				targetFiles[0] = importPath;
			}

			counter.Text = string.Concat("0 / ", maxCounter);
			ttlProgress.Maximum = maxCounter;
			logText.AppendText("変換を開始しています！");
			Application.DoEvents();

			foreach (string file in targetFiles)
			{
				if (file == null)
				{
					break;
				}

				initializeCheck.CheckState = CheckState.Unchecked;
				unZipCheck.CheckState = CheckState.Unchecked;
				convertCheck.CheckState = CheckState.Unchecked;
				convertCheck.CheckState = CheckState.Unchecked;
				compressCheck.CheckState = CheckState.Unchecked;
				cleanupWorkDirCheck.CheckState = CheckState.Unchecked;

				statProgress.Value = 0;
				counter.Text = string.Concat(currentCount, " / ", maxCounter);
				string exportPath2 = fileMode ? exportPath : Path.Combine(exportPath, Path.GetFileNameWithoutExtension(file) + "_convert.zip");

				// ワークディレクトリ内ファイルクリーン（P1）
				addInfoMessage("ワークディレクトリ内ファイルクリーンを開始");
				statProgress.Value++;
				initializeCheck.CheckState = CheckState.Indeterminate;
				Application.DoEvents();
				cleanWorkDir(workDir, workKey);
				initializeCheck.CheckState = CheckState.Checked;

				// ZIPファイル抽出（P2）
				addInfoMessage("ZIPファイルの抽出を開始");
				statProgress.Value++;
				unZipCheck.CheckState = CheckState.Indeterminate;
				Application.DoEvents();
				if (!UnZip(file, workDir, workKey))
				{
					addInfoMessage("処理を中断しました。");
					closeButton.Enabled = true;
					return;
				}
				unZipCheck.CheckState = CheckState.Checked;

				// ファイル変換（P3）
				addInfoMessage("ファイルの変換を開始");
				statProgress.Value++;
				convertCheck.CheckState = CheckState.Indeterminate;
				Application.DoEvents();
				if (!convertToJpg(workDir, quality, workKey))
				{
					addInfoMessage("処理を中断しました。");
					closeButton.Enabled = true;
					return;
				}
				convertCheck.CheckState = CheckState.Checked;

				// 再圧縮（P4）
				addInfoMessage("ファイルの再圧縮を開始");
				statProgress.Value++;
				compressCheck.CheckState = CheckState.Indeterminate;
				Application.DoEvents();
				if (!compress(Path.Combine(workDir, "convert"), exportPath2, workKey))
				{
					addInfoMessage("処理を中断しました。");
					closeButton.Enabled = true;
					return;
				}
				compressCheck.CheckState = CheckState.Checked;

				// ワークディレクトリ内ファイルクリーン（P5）
				addInfoMessage("ワークディレクトリ内ファイルクリーンを開始");
				statProgress.Value++;
				cleanupWorkDirCheck.CheckState = CheckState.Unchecked;
				Application.DoEvents();
				cleanWorkDir(workDir, workKey);
				cleanupWorkDirCheck.CheckState = CheckState.Checked;

				// 完了処理（P6）
				addInfoMessage("最終処理中");
				statProgress.Value++;
				Application.DoEvents();
				if (delFlg)
				{
					try
					{
						File.Delete(file);
						if (renameFlg)
						{
							File.Move(exportPath2, file);
						}
					}
					catch (Exception ex)
					{
						addErrorMessage(ex.Message, file, workKey);
						cleanWorkDir(workDir, workKey);
					}
				}
				ttlProgress.Value++;
				currentCount++;
				counter.Text = string.Concat(currentCount, " / ", maxCounter);
				Application.DoEvents();
			}
			MessageBox.Show("処理完了！（ワークキー：" + workKey + "）\n保存先\n[" + ((delFlg && renameFlg) ? importPath : exportPath) + "]", Main.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			Close();
		}

		private int getTargetFilesCounter(string baseFilePath)
		{
			targetFiles = Directory.GetFiles(baseFilePath, "*.zip", SearchOption.AllDirectories);
			return targetFiles.Count();
		}

		private bool UnZip(string unZipFilePath, string workDir, string workKey)
		{
			bool result = true;

			// 展開元ファイル存在チェック
			if (!File.Exists(unZipFilePath))
			{
				addErrorMessage("ファイルが見つかりません", unZipFilePath, workKey);
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
					addErrorMessage(ex.Message, workDir, workKey);
					return false;
				}
			}

			try
			{
				EncodingProvider provider = System.Text.CodePagesEncodingProvider.Instance;
				ZipFile.ExtractToDirectory(unZipFilePath, workDir, provider.GetEncoding("shift-jis"), true);
			}
			catch (Exception ex)
			{
				addErrorMessage(ex.Message, unZipFilePath, workDir);
				cleanWorkDir(workDir, workKey);
				return false;
			}
			return result;
		}

		private bool convertToJpg(string workDir, int quality, string workKey)
		{
			bool result = true;
			if (Directory.GetFiles(workDir, "*.webp", SearchOption.AllDirectories).Length == 0)
			{
				addErrorMessage("webpファイルがありません", workDir, workKey);
				cleanWorkDir(workDir, workKey);
				return false;
			}

			// コンバートフォルダ作成
			if (!Directory.Exists(Path.Combine(workDir, "convert")))
			{
				try
				{
					Directory.CreateDirectory(Path.Combine(workDir, "convert"));
				}
				catch (Exception ex)
				{
					addErrorMessage(ex.Message, Path.Combine(workDir, "convert"), workKey);
					cleanWorkDir(workDir, workKey);
					return false;
				}
			}

			// 変換処理
			foreach (string file in Directory.GetFiles(workDir, "*.webp", SearchOption.AllDirectories))
			{
				string fileName = Path.GetFileNameWithoutExtension(file);
				string outputPath = Path.Combine(workDir, "convert", fileName + ".jpg");

				try
				{
					// 変換
					save(file, outputPath, ImageFormat.Jpeg, quality);
				}
				catch (Exception ex)
				{
					addErrorMessage(ex.Message, file, workKey);
					cleanWorkDir(workDir, workKey);
					return false;
				}
			}

			// 変換後ファイル存在チェック
			string convertedDir = Path.Combine(workDir, "convert");
			if (Directory.GetFiles(convertedDir, "*.jpg", SearchOption.AllDirectories).Length == 0)
			{
				addErrorMessage("変換後のjpgファイルがありません", workDir, workKey);
				cleanWorkDir(workDir, workKey);
				return false;
			}
			return result;
		}

		private bool compress(string workDir, string targetPath, string workKey)
		{
			bool result = true;
			try
			{
				if (!Directory.Exists(Path.GetDirectoryName(targetPath)))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(targetPath));
				}
				ZipFile.CreateFromDirectory(workDir, targetPath);
			}
			catch (Exception ex)
			{
				addErrorMessage(ex.Message, workDir, targetPath);
				cleanWorkDir(workDir, workKey);
				return false;
			}
			return result;
		}

		private bool cleanWorkDir(string workDir, string workKey)
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
				addErrorMessage(ex.Message, workDir, workKey);
				return false;
			}
			return result;
		}

		private void save(string inputFile, string outputFile, ImageFormat format, int quality)
		{
			var wf = new WebPFormat();
			wf.Quality = quality;
			Stream stream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
			var image = (Bitmap)wf.Load(stream);
			stream.Close();
			ImageFactory imgfactory = new ImageFactory();
			imgfactory.Load(image);
			imgfactory.Format(wf);
			imgfactory.Save(outputFile);
		}

		public void addErrorMessage(string message, string path, string workKey, string appendMessage = "")
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("[ERROR] (").Append(workKey).Append(") ").Append(message).Append(" [").Append(path).Append("] ").Append(appendMessage).Append(" (").Append(DateTime.Now).Append(")");
			MessageBox.Show(sb.ToString(), Main.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void addInfoMessage(string message)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("\n[INFO] ").Append(message).Append(" (").Append(DateTime.Now).Append(")");
			message = sb.ToString();
			logText.AppendText(message);
			return;
		}
	}
}
