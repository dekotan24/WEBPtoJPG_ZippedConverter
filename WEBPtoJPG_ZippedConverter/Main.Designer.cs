namespace WEBPtoJPG_ZippedConverter
{
	partial class Main
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.importZipDirectoryRadio = new System.Windows.Forms.RadioButton();
			this.importZipDirectoryBrowseButton = new System.Windows.Forms.Button();
			this.importZipDirectoryPathText = new System.Windows.Forms.TextBox();
			this.importZipFileRadio = new System.Windows.Forms.RadioButton();
			this.workFolderBrowseText = new System.Windows.Forms.Button();
			this.workFolderPathText = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.importZipFileBrowseButton = new System.Windows.Forms.Button();
			this.importZipFilePathText = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.exportZipPathText = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.exportZipPathBrowseButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.executeButton = new System.Windows.Forms.Button();
			this.logText = new System.Windows.Forms.RichTextBox();
			this.titleLabel = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.encodingList = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.qualityText = new System.Windows.Forms.NumericUpDown();
			this.renameCheck = new System.Windows.Forms.CheckBox();
			this.oldFileDelCheck = new System.Windows.Forms.CheckBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.qualityText)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.importZipDirectoryRadio);
			this.groupBox1.Controls.Add(this.importZipDirectoryBrowseButton);
			this.groupBox1.Controls.Add(this.importZipDirectoryPathText);
			this.groupBox1.Controls.Add(this.importZipFileRadio);
			this.groupBox1.Controls.Add(this.workFolderBrowseText);
			this.groupBox1.Controls.Add(this.workFolderPathText);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.importZipFileBrowseButton);
			this.groupBox1.Controls.Add(this.importZipFilePathText);
			this.groupBox1.Location = new System.Drawing.Point(12, 35);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(576, 193);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "変換元（*.zipが処理対象）";
			// 
			// importZipDirectoryRadio
			// 
			this.importZipDirectoryRadio.AutoSize = true;
			this.importZipDirectoryRadio.Location = new System.Drawing.Point(6, 76);
			this.importZipDirectoryRadio.Name = "importZipDirectoryRadio";
			this.importZipDirectoryRadio.Size = new System.Drawing.Size(106, 19);
			this.importZipDirectoryRadio.TabIndex = 8;
			this.importZipDirectoryRadio.Text = "フォルダ内ファイル";
			this.importZipDirectoryRadio.UseVisualStyleBackColor = true;
			this.importZipDirectoryRadio.CheckedChanged += new System.EventHandler(this.importZipDirectoryRadio_CheckedChanged);
			// 
			// importZipDirectoryBrowseButton
			// 
			this.importZipDirectoryBrowseButton.Enabled = false;
			this.importZipDirectoryBrowseButton.Location = new System.Drawing.Point(545, 101);
			this.importZipDirectoryBrowseButton.Name = "importZipDirectoryBrowseButton";
			this.importZipDirectoryBrowseButton.Size = new System.Drawing.Size(25, 23);
			this.importZipDirectoryBrowseButton.TabIndex = 7;
			this.importZipDirectoryBrowseButton.Text = "..";
			this.importZipDirectoryBrowseButton.UseVisualStyleBackColor = true;
			this.importZipDirectoryBrowseButton.Click += new System.EventHandler(this.importZipDirectoryBrowseButton_Click);
			// 
			// importZipDirectoryPathText
			// 
			this.importZipDirectoryPathText.Enabled = false;
			this.importZipDirectoryPathText.Location = new System.Drawing.Point(6, 101);
			this.importZipDirectoryPathText.Name = "importZipDirectoryPathText";
			this.importZipDirectoryPathText.Size = new System.Drawing.Size(533, 23);
			this.importZipDirectoryPathText.TabIndex = 6;
			this.toolTip1.SetToolTip(this.importZipDirectoryPathText, "変換元ファイルが存在するZIPファイルを入力");
			// 
			// importZipFileRadio
			// 
			this.importZipFileRadio.AutoSize = true;
			this.importZipFileRadio.Checked = true;
			this.importZipFileRadio.Location = new System.Drawing.Point(6, 22);
			this.importZipFileRadio.Name = "importZipFileRadio";
			this.importZipFileRadio.Size = new System.Drawing.Size(83, 19);
			this.importZipFileRadio.TabIndex = 5;
			this.importZipFileRadio.TabStop = true;
			this.importZipFileRadio.Text = "単一ファイル";
			this.importZipFileRadio.UseVisualStyleBackColor = true;
			this.importZipFileRadio.CheckedChanged += new System.EventHandler(this.importZipFileRadio_CheckedChanged);
			// 
			// workFolderBrowseText
			// 
			this.workFolderBrowseText.Location = new System.Drawing.Point(545, 161);
			this.workFolderBrowseText.Name = "workFolderBrowseText";
			this.workFolderBrowseText.Size = new System.Drawing.Size(25, 23);
			this.workFolderBrowseText.TabIndex = 4;
			this.workFolderBrowseText.Text = "..";
			this.workFolderBrowseText.UseVisualStyleBackColor = true;
			this.workFolderBrowseText.Click += new System.EventHandler(this.workFolderBrowseText_Click);
			// 
			// workFolderPathText
			// 
			this.workFolderPathText.Location = new System.Drawing.Point(6, 161);
			this.workFolderPathText.Name = "workFolderPathText";
			this.workFolderPathText.Size = new System.Drawing.Size(533, 23);
			this.workFolderPathText.TabIndex = 3;
			this.toolTip1.SetToolTip(this.workFolderPathText, "一時的に展開する際に使用する作業フォルダ");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 143);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "ワークフォルダ";
			// 
			// importZipFileBrowseButton
			// 
			this.importZipFileBrowseButton.Location = new System.Drawing.Point(545, 47);
			this.importZipFileBrowseButton.Name = "importZipFileBrowseButton";
			this.importZipFileBrowseButton.Size = new System.Drawing.Size(25, 23);
			this.importZipFileBrowseButton.TabIndex = 2;
			this.importZipFileBrowseButton.Text = "..";
			this.importZipFileBrowseButton.UseVisualStyleBackColor = true;
			this.importZipFileBrowseButton.Click += new System.EventHandler(this.importZipFileBrowseButton_Click);
			// 
			// importZipFilePathText
			// 
			this.importZipFilePathText.Location = new System.Drawing.Point(6, 47);
			this.importZipFilePathText.Name = "importZipFilePathText";
			this.importZipFilePathText.Size = new System.Drawing.Size(533, 23);
			this.importZipFilePathText.TabIndex = 1;
			this.toolTip1.SetToolTip(this.importZipFilePathText, "変換元ファイルが存在するZIPファイルを入力");
			// 
			// exportZipPathText
			// 
			this.exportZipPathText.Location = new System.Drawing.Point(6, 37);
			this.exportZipPathText.Name = "exportZipPathText";
			this.exportZipPathText.Size = new System.Drawing.Size(533, 23);
			this.exportZipPathText.TabIndex = 5;
			this.toolTip1.SetToolTip(this.exportZipPathText, "変換元ファイルが存在するZIPファイルを入力");
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.exportZipPathBrowseButton);
			this.groupBox2.Controls.Add(this.exportZipPathText);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Enabled = false;
			this.groupBox2.Location = new System.Drawing.Point(12, 234);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(576, 74);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "変換先";
			// 
			// exportZipPathBrowseButton
			// 
			this.exportZipPathBrowseButton.Location = new System.Drawing.Point(545, 37);
			this.exportZipPathBrowseButton.Name = "exportZipPathBrowseButton";
			this.exportZipPathBrowseButton.Size = new System.Drawing.Size(25, 23);
			this.exportZipPathBrowseButton.TabIndex = 6;
			this.exportZipPathBrowseButton.Text = "..";
			this.exportZipPathBrowseButton.UseVisualStyleBackColor = true;
			this.exportZipPathBrowseButton.Click += new System.EventHandler(this.exportZipFileBrowseButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(153, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "ZIPファイル/フォルダ出力先パス";
			// 
			// executeButton
			// 
			this.executeButton.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold);
			this.executeButton.Location = new System.Drawing.Point(12, 374);
			this.executeButton.Name = "executeButton";
			this.executeButton.Size = new System.Drawing.Size(576, 68);
			this.executeButton.TabIndex = 10;
			this.executeButton.Text = "変換！";
			this.executeButton.UseVisualStyleBackColor = true;
			this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
			// 
			// logText
			// 
			this.logText.Location = new System.Drawing.Point(12, 448);
			this.logText.Name = "logText";
			this.logText.Size = new System.Drawing.Size(576, 81);
			this.logText.TabIndex = 11;
			this.logText.Text = "";
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Yu Gothic UI", 12F);
			this.titleLabel.Location = new System.Drawing.Point(113, 6);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(323, 21);
			this.titleLabel.TabIndex = 5;
			this.titleLabel.Text = "ZIP圧縮されたwebpファイルをjpgに変換するツール";
			// 
			// versionLabel
			// 
			this.versionLabel.AutoSize = true;
			this.versionLabel.Location = new System.Drawing.Point(441, 12);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(40, 15);
			this.versionLabel.TabIndex = 6;
			this.versionLabel.Text = "Ver.x.x";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.encodingList);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.qualityText);
			this.groupBox3.Controls.Add(this.renameCheck);
			this.groupBox3.Controls.Add(this.oldFileDelCheck);
			this.groupBox3.Location = new System.Drawing.Point(12, 314);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(576, 54);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "オプション";
			// 
			// encodingList
			// 
			this.encodingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.encodingList.FormattingEnabled = true;
			this.encodingList.Items.AddRange(new object[] {
            "Shift-JIS"});
			this.encodingList.Location = new System.Drawing.Point(380, 19);
			this.encodingList.Name = "encodingList";
			this.encodingList.Size = new System.Drawing.Size(89, 23);
			this.encodingList.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(470, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 15);
			this.label4.TabIndex = 3;
			this.label4.Text = "画質(%)";
			// 
			// qualityText
			// 
			this.qualityText.Location = new System.Drawing.Point(525, 21);
			this.qualityText.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.qualityText.Name = "qualityText";
			this.qualityText.Size = new System.Drawing.Size(45, 23);
			this.qualityText.TabIndex = 9;
			this.qualityText.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
			// 
			// renameCheck
			// 
			this.renameCheck.AutoSize = true;
			this.renameCheck.Checked = true;
			this.renameCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.renameCheck.Location = new System.Drawing.Point(118, 21);
			this.renameCheck.Name = "renameCheck";
			this.renameCheck.Size = new System.Drawing.Size(152, 19);
			this.renameCheck.TabIndex = 8;
			this.renameCheck.Text = "変換元ファイル名にリネーム";
			this.renameCheck.UseVisualStyleBackColor = true;
			this.renameCheck.CheckedChanged += new System.EventHandler(this.renameCheck_CheckedChanged);
			// 
			// oldFileDelCheck
			// 
			this.oldFileDelCheck.AutoSize = true;
			this.oldFileDelCheck.Checked = true;
			this.oldFileDelCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.oldFileDelCheck.Location = new System.Drawing.Point(7, 21);
			this.oldFileDelCheck.Name = "oldFileDelCheck";
			this.oldFileDelCheck.Size = new System.Drawing.Size(105, 19);
			this.oldFileDelCheck.TabIndex = 7;
			this.oldFileDelCheck.Text = "元ファイルを削除";
			this.oldFileDelCheck.UseVisualStyleBackColor = true;
			this.oldFileDelCheck.CheckedChanged += new System.EventHandler(this.oldFileDelCheck_CheckedChanged);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(511, 17);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(77, 15);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "使用上の注意";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// Main
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 541);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.logText);
			this.Controls.Add(this.executeButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Main";
			this.Text = "WEBP to JPG Zipped Converter";
			this.Load += new System.EventHandler(this.Main_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AddItem_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.AddItem_DragEnter);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.qualityText)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private GroupBox groupBox1;
		private Button importZipFileBrowseButton;
		private TextBox importZipFilePathText;
		private Label label2;
		private Button workFolderBrowseText;
		private TextBox workFolderPathText;
		private ToolTip toolTip1;
		private GroupBox groupBox2;
		private Button exportZipPathBrowseButton;
		private TextBox exportZipPathText;
		private Label label3;
		private Button executeButton;
		private Label titleLabel;
		private Label versionLabel;
		private OpenFileDialog openFileDialog1;
		private FolderBrowserDialog folderBrowserDialog1;
		private SaveFileDialog saveFileDialog1;
		public RichTextBox logText;
		private GroupBox groupBox3;
		private Label label4;
		private NumericUpDown qualityText;
		private CheckBox renameCheck;
		private CheckBox oldFileDelCheck;
		private RadioButton importZipDirectoryRadio;
		private Button importZipDirectoryBrowseButton;
		private TextBox importZipDirectoryPathText;
		private RadioButton importZipFileRadio;
		private ComboBox encodingList;
		private LinkLabel linkLabel1;
	}
}