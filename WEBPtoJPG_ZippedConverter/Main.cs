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

		private void importZipDirectoryBrowseButton_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1 = new FolderBrowserDialog();
			folderBrowserDialog1.Description = "�ϊ���ZIP�t�@�C�����܂܂��t�H���_��I��";
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
			folderBrowserDialog1.Description = "��ƃt�H���_��I��";
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
				saveFileDialog1.Title = "�ϊ���ZIP�t�@�C���ۑ����I��";
				saveFileDialog1.Filter = "ZIP�t�@�C��(*.zip)|*.zip";
				saveFileDialog1.FileName = "";
				if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
				{
					exportZipPathText.Text = saveFileDialog1.FileName;
				}
			}
			else
			{
				folderBrowserDialog1 = new FolderBrowserDialog();
				folderBrowserDialog1.Description = "�ϊ����ZIP�t�@�C����ۑ�����t�H���_��I��";
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
				MessageBox.Show("�Q�ƌ�ZIP�t�@�C���͕K�{�ł��B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				importZipFilePathText.Focus();
				return;
			}
			if (importZipDirectoryPathText.Text.Trim().Length == 0 && importZipDirectoryRadio.Checked)
			{
				MessageBox.Show("�Q�ƌ�ZIP�f�B���N�g���͕K�{�ł��B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				importZipDirectoryPathText.Focus();
				return;
			}
			if (workFolderPathText.Text.Trim().Length == 0)
			{
				MessageBox.Show("���[�N�t�H���_�͕K�{�ł��B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				workFolderPathText.Focus();
				return;
			}
			if (exportZipPathText.Text.Trim().Length == 0)
			{
				MessageBox.Show("�ϊ���ZIP�t�@�C���͕K�{�ł��B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				exportZipPathText.Focus();
				return;
			}
			if (File.Exists(exportZipPathText.Text.Trim()))
			{
				MessageBox.Show("�ϊ���ZIP�t�@�C���p�X�͊��ɑ��݂��Ă��܂��B\n���݂��Ȃ��t�@�C�������w�肵�Ă��������B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				exportZipPathText.Focus();
				return;
			}
			if (!(Path.GetExtension(importZipFilePathText.Text.Trim()).ToUpper() == ".ZIP") && importZipFileRadio.Checked)
			{
				MessageBox.Show("�Q�ƌ�ZIP�t�@�C���p�X��ZIP�t�@�C���ł͂���܂���B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				importZipFilePathText.Focus();
				return;
			}
			if (!(Path.GetExtension(exportZipPathText.Text.Trim()).ToUpper() == ".ZIP") && importZipFileRadio.Checked)
			{
				MessageBox.Show("�ϊ���ZIP�t�@�C���p�X��ZIP�t�@�C���ł͂���܂���B", AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
			addInfoMessage("�����J�n�I�����͕ʃX���b�h�Ŏ��s����Ă��܂��B�_�C�A���O���\�������܂ł��΂炭���҂��������B\n�Ώۃt�@�C���F" + importPath + "\n���[�N�L�[�F" + workKey);

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
				// �t�@�C���̏ꍇ
				fullPath = Path.Combine(Path.GetDirectoryName(basePath), Path.GetFileNameWithoutExtension(basePath) + "_convert.zip");
			}
			else
			{
				// �t�H���_�̏ꍇ
				fullPath = Path.Combine(Path.GetDirectoryName(basePath), "convert");
			}
			exportZipPathText.Text = fullPath;
		}

		private void AddItem_DragDrop(object sender, DragEventArgs e)
		{
			// DataFormats.FileDrop��^���āAGetDataPresent()���\�b�h���Ăяo���B
			var dropTarget = (string[])e.Data.GetData(DataFormats.FileDrop, false);

			// GetData�ɂ��擾����String�^�̔z�񂩂�v�f�����o���B
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
			// �����_�����[�N�L�[�쐬
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
			MessageBox.Show("�y���ӁI�z\n�E�{�c�[�����g�p����ƁAZIP�t�@�C�����̃f�B���N�g���\�������܂��B\n�i�S�Ẵt�@�C�������[�g�p�X�Ɉ��k����܂��j\n\n�E��L�̎d�l��A�������O�̃t�@�C�������Ɨ\�����ʕs�����������\���������ł��B\n\n�E�����R�[�h��Shift-JIS�̂ݑΉ����Ă��܂��B\n�G���R�[�h���Ⴄ�ƁA�𓀎��ɃG���[�ɂȂ�ꍇ������܂��B\nShift-JIS�ōĈ��k���Ă��������B\n\n�����Ȃ鑹�Q�E�����Ȃǂ���؂̐ӔC�𕉂��܂���B\n���ȐӔC�ł����p���������B", "�����N�Ɍ��������ă_�C�A���O", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}