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

			// �����_�����[�N�L�[�쐬
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
			openFileDialog1.Title = "�ϊ���ZIP�t�@�C����I��";
			openFileDialog1.Filter = "ZIP�t�@�C��(*.zip)|*.zip";
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
			folderBrowserDialog1.Description = "��ƃt�H���_��I��";
			if (folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
			{
				workFolderPathText.Text = ((folderBrowserDialog1.SelectedPath).EndsWith("\\") ? folderBrowserDialog1.SelectedPath : folderBrowserDialog1.SelectedPath + "\\") + randomKey + "\\";
			}
			return;
		}

		private void exportZipFileBrowseButton_Click(object sender, EventArgs e)
		{
			saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Title = "�ϊ���ZIP�t�@�C���ۑ����I��";
			saveFileDialog1.Filter = "ZIP�t�@�C��(*.zip)|*.zip";
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
				MessageBox.Show("�Q�ƌ�ZIP�t�@�C���͕K�{�ł��B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				importZipFilePathText.Focus();
				return;
			}
			if (workFolderPathText.Text.Trim().Length == 0)
			{
				MessageBox.Show("���[�N�t�H���_�͕K�{�ł��B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				workFolderPathText.Focus();
				return;
			}
			if (exportZipFilePathText.Text.Trim().Length == 0)
			{
				MessageBox.Show("�ϊ���ZIP�t�@�C���͕K�{�ł��B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				exportZipFilePathText.Focus();
				return;
			}
			if (File.Exists(exportZipFilePathText.Text.Trim()))
			{
				MessageBox.Show("�ϊ���ZIP�t�@�C���p�X�͊��ɑ��݂��Ă��܂��B\n���݂��Ȃ��t�@�C�������w�肵�Ă��������B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				exportZipFilePathText.Focus();
				return;
			}
			if (!(Path.GetExtension(importZipFilePathText.Text.Trim()).ToUpper() == ".ZIP"))
			{
				MessageBox.Show("�Q�ƌ�ZIP�t�@�C���p�X��ZIP�t�@�C���ł͂���܂���B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				importZipFilePathText.Focus();
				return;
			}
			if (!(Path.GetExtension(exportZipFilePathText.Text.Trim()).ToUpper() == ".ZIP"))
			{
				MessageBox.Show("�ϊ���ZIP�t�@�C���p�X��ZIP�t�@�C���ł͂���܂���B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				exportZipFilePathText.Focus();
				return;
			}

			string importPath = importZipFilePathText.Text.Trim();
			string workDir = workFolderPathText.Text.Trim();
			string exportPath = exportZipFilePathText.Text.Trim();

			logText.Clear();
			logText.AppendText(AppName + " Ver." + ProductVersion);
			addInfoMessage("�����J�n�I\n�����͕ʃX���b�h�Ŏ��s����Ă��܂��B�_�C�A���O���\�������܂ł��΂炭���҂��������B");

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

			// ���[�N�f�B���N�g�����t�@�C���N���[��
			addInfoMessage("���[�N�f�B���N�g�����t�@�C���N���[�����J�n");
			cleanWorkDir(workDir);

			// ZIP�t�@�C�����o
			addInfoMessage("ZIP�t�@�C���̒��o���J�n");

			if (!UnZip(baseFilePath, workDir))
			{
				addInfoMessage("�����𒆒f���܂����B");
				return;
			}

			// �t�@�C���ϊ�
			addInfoMessage("�t�@�C���̕ϊ����J�n");
			if (!convertToJpg(workDir))
			{
				addInfoMessage("�����𒆒f���܂����B");
				return;
			}

			// �Ĉ��k
			addInfoMessage("�t�@�C���̍Ĉ��k���J�n");
			if (!compress(workDir + "convert", saveFilePath))
			{
				addInfoMessage("�����𒆒f���܂����B");
				return;
			}

			// ���[�N�f�B���N�g�����t�@�C���N���[��
			addInfoMessage("���[�N�f�B���N�g�����t�@�C���N���[�����J�n");
			cleanWorkDir(workDir);

			// ��������
			addInfoMessage("�����I\n�ۑ���F" + saveFilePath);
			MessageBox.Show("���������I\n�ۑ���\n[" + saveFilePath + "]", AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

			return;
		}

		private bool UnZip(string unZipFilePath, string workDir)
		{
			bool result = true;

			// �W�J���t�@�C�����݃`�F�b�N
			if (!File.Exists(unZipFilePath))
			{
				addErrorMessage("�t�@�C����������܂���", unZipFilePath);
				return false;
			}

			// ��ƃf�B���N�g�����݃`�F�b�N
			if (!Directory.Exists(workDir))
			{
				// ���݂��Ȃ��ꍇ�A�t�H���_�쐬
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
				addErrorMessage("webp�t�@�C��������܂���", workDir);
				cleanWorkDir(workDir);
				return false;
			}

			// �R���o�[�g�t�H���_�쐬
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

			// �ϊ�����
			foreach (string file in Directory.GetFiles(workDir, "*.webp", SearchOption.TopDirectoryOnly))
			{
				string fileName = Path.GetFileNameWithoutExtension(file);
				string outputPath = workDir + "convert\\" + fileName + ".jpg";

				try
				{
					// �ϊ�
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
			// DataFormats.FileDrop��^���āAGetDataPresent()���\�b�h���Ăяo���B
			var dropTarget = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			// GetData�ɂ��擾����String�^�̔z�񂩂�v�f�����o���B
			var targetFile = dropTarget[0];

			importZipFilePathText.Text = targetFile;
			autoComplete(targetFile);
		}

		private void AddItem_DragEnter(object sender, DragEventArgs e)
		{
			// �}�E�X�|�C���^�[�`��ύX
			//
			// DragDropEffects
			//  Copy  :�f�[�^���h���b�v��ɃR�s�[����悤�Ƃ��Ă�����
			//  Move  :�f�[�^���h���b�v��Ɉړ�����悤�Ƃ��Ă�����
			//  Scroll:�f�[�^�ɂ���ăh���b�v��ŃX�N���[�����J�n����悤�Ƃ��Ă����ԁA���邢�͌��݃X�N���[�����ł�����
			//  All   :���3��g�ݍ��킹������
			//  Link  :�f�[�^�̃����N���h���b�v��ɍ쐬����悤�Ƃ��Ă�����
			//  None  :�����Ȃ�f�[�^���h���b�v�悪�󂯕t���悤�Ƃ��Ȃ����

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