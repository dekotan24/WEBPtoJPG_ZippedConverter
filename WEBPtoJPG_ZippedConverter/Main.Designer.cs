﻿namespace WEBPtoJPG_ZippedConverter
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
			this.workFolderBrowseText = new System.Windows.Forms.Button();
			this.workFolderPathText = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.importZipFileBrowseButton = new System.Windows.Forms.Button();
			this.importZipFilePathText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.exportZipFilePathText = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.exportZipFileBrowseButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.executeButton = new System.Windows.Forms.Button();
			this.logText = new System.Windows.Forms.RichTextBox();
			this.titleLabel = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.workFolderBrowseText);
			this.groupBox1.Controls.Add(this.workFolderPathText);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.importZipFileBrowseButton);
			this.groupBox1.Controls.Add(this.importZipFilePathText);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 35);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(530, 142);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "変換元";
			// 
			// workFolderBrowseText
			// 
			this.workFolderBrowseText.Location = new System.Drawing.Point(494, 94);
			this.workFolderBrowseText.Name = "workFolderBrowseText";
			this.workFolderBrowseText.Size = new System.Drawing.Size(25, 23);
			this.workFolderBrowseText.TabIndex = 5;
			this.workFolderBrowseText.Text = "..";
			this.workFolderBrowseText.UseVisualStyleBackColor = true;
			this.workFolderBrowseText.Click += new System.EventHandler(this.workFolderBrowseText_Click);
			// 
			// workFolderPathText
			// 
			this.workFolderPathText.Location = new System.Drawing.Point(6, 94);
			this.workFolderPathText.Name = "workFolderPathText";
			this.workFolderPathText.Size = new System.Drawing.Size(482, 23);
			this.workFolderPathText.TabIndex = 4;
			this.toolTip1.SetToolTip(this.workFolderPathText, "一時的に展開する際に使用する作業フォルダ");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "ワークフォルダ";
			// 
			// importZipFileBrowseButton
			// 
			this.importZipFileBrowseButton.Location = new System.Drawing.Point(494, 37);
			this.importZipFileBrowseButton.Name = "importZipFileBrowseButton";
			this.importZipFileBrowseButton.Size = new System.Drawing.Size(25, 23);
			this.importZipFileBrowseButton.TabIndex = 2;
			this.importZipFileBrowseButton.Text = "..";
			this.importZipFileBrowseButton.UseVisualStyleBackColor = true;
			this.importZipFileBrowseButton.Click += new System.EventHandler(this.importZipFileBrowseButton_Click);
			// 
			// importZipFilePathText
			// 
			this.importZipFilePathText.Location = new System.Drawing.Point(6, 37);
			this.importZipFilePathText.Name = "importZipFilePathText";
			this.importZipFilePathText.Size = new System.Drawing.Size(482, 23);
			this.importZipFilePathText.TabIndex = 1;
			this.toolTip1.SetToolTip(this.importZipFilePathText, "変換元ファイルが存在するZIPファイルを入力");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "ZIPファイル";
			// 
			// exportZipFilePathText
			// 
			this.exportZipFilePathText.Location = new System.Drawing.Point(6, 37);
			this.exportZipFilePathText.Name = "exportZipFilePathText";
			this.exportZipFilePathText.Size = new System.Drawing.Size(482, 23);
			this.exportZipFilePathText.TabIndex = 4;
			this.toolTip1.SetToolTip(this.exportZipFilePathText, "変換元ファイルが存在するZIPファイルを入力");
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.exportZipFileBrowseButton);
			this.groupBox2.Controls.Add(this.exportZipFilePathText);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(12, 188);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(530, 78);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "変換先";
			// 
			// exportZipFileBrowseButton
			// 
			this.exportZipFileBrowseButton.Location = new System.Drawing.Point(494, 37);
			this.exportZipFileBrowseButton.Name = "exportZipFileBrowseButton";
			this.exportZipFileBrowseButton.Size = new System.Drawing.Size(25, 23);
			this.exportZipFileBrowseButton.TabIndex = 5;
			this.exportZipFileBrowseButton.Text = "..";
			this.exportZipFileBrowseButton.UseVisualStyleBackColor = true;
			this.exportZipFileBrowseButton.Click += new System.EventHandler(this.exportZipFileBrowseButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "ZIPファイル";
			// 
			// executeButton
			// 
			this.executeButton.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold);
			this.executeButton.Location = new System.Drawing.Point(12, 283);
			this.executeButton.Name = "executeButton";
			this.executeButton.Size = new System.Drawing.Size(530, 68);
			this.executeButton.TabIndex = 2;
			this.executeButton.Text = "変換！";
			this.executeButton.UseVisualStyleBackColor = true;
			this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
			// 
			// logText
			// 
			this.logText.Location = new System.Drawing.Point(12, 375);
			this.logText.Name = "logText";
			this.logText.Size = new System.Drawing.Size(530, 71);
			this.logText.TabIndex = 4;
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
			// Main
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(554, 457);
			this.Controls.Add(this.versionLabel);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.logText);
			this.Controls.Add(this.executeButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Main";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Main_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AddItem_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.AddItem_DragEnter);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private GroupBox groupBox1;
		private Button importZipFileBrowseButton;
		private TextBox importZipFilePathText;
		private Label label1;
		private Label label2;
		private Button workFolderBrowseText;
		private TextBox workFolderPathText;
		private ToolTip toolTip1;
		private GroupBox groupBox2;
		private Button exportZipFileBrowseButton;
		private TextBox exportZipFilePathText;
		private Label label3;
		private Button executeButton;
		private Label titleLabel;
		private Label versionLabel;
		private OpenFileDialog openFileDialog1;
		private FolderBrowserDialog folderBrowserDialog1;
		private SaveFileDialog saveFileDialog1;
		public RichTextBox logText;
	}
}