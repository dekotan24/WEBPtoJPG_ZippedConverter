namespace WEBPtoJPG_ZippedConverter
{
	partial class Exec
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ttlProgress = new System.Windows.Forms.ProgressBar();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.wkKey = new System.Windows.Forms.Label();
			this.initializeCheck = new System.Windows.Forms.CheckBox();
			this.unZipCheck = new System.Windows.Forms.CheckBox();
			this.convertCheck = new System.Windows.Forms.CheckBox();
			this.compressCheck = new System.Windows.Forms.CheckBox();
			this.cleanupWorkDirCheck = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.counter = new System.Windows.Forms.Label();
			this.statProgress = new System.Windows.Forms.ProgressBar();
			this.logText = new System.Windows.Forms.RichTextBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ttlProgress
			// 
			this.ttlProgress.Location = new System.Drawing.Point(12, 12);
			this.ttlProgress.Name = "ttlProgress";
			this.ttlProgress.Size = new System.Drawing.Size(264, 11);
			this.ttlProgress.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 46);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(264, 23);
			this.textBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "ワークキー：";
			// 
			// wkKey
			// 
			this.wkKey.AutoSize = true;
			this.wkKey.Location = new System.Drawing.Point(80, 72);
			this.wkKey.Name = "wkKey";
			this.wkKey.Size = new System.Drawing.Size(37, 15);
			this.wkKey.TabIndex = 3;
			this.wkKey.Text = "xxxxx";
			// 
			// initializeCheck
			// 
			this.initializeCheck.AutoSize = true;
			this.initializeCheck.Enabled = false;
			this.initializeCheck.Location = new System.Drawing.Point(12, 90);
			this.initializeCheck.Name = "initializeCheck";
			this.initializeCheck.Size = new System.Drawing.Size(86, 19);
			this.initializeCheck.TabIndex = 4;
			this.initializeCheck.Text = "クリーンアップ";
			this.initializeCheck.UseVisualStyleBackColor = true;
			// 
			// unZipCheck
			// 
			this.unZipCheck.AutoSize = true;
			this.unZipCheck.Enabled = false;
			this.unZipCheck.Location = new System.Drawing.Point(12, 115);
			this.unZipCheck.Name = "unZipCheck";
			this.unZipCheck.Size = new System.Drawing.Size(50, 19);
			this.unZipCheck.TabIndex = 5;
			this.unZipCheck.Text = "解凍";
			this.unZipCheck.UseVisualStyleBackColor = true;
			// 
			// convertCheck
			// 
			this.convertCheck.AutoSize = true;
			this.convertCheck.Enabled = false;
			this.convertCheck.Location = new System.Drawing.Point(12, 140);
			this.convertCheck.Name = "convertCheck";
			this.convertCheck.Size = new System.Drawing.Size(50, 19);
			this.convertCheck.TabIndex = 6;
			this.convertCheck.Text = "変換";
			this.convertCheck.UseVisualStyleBackColor = true;
			// 
			// compressCheck
			// 
			this.compressCheck.AutoSize = true;
			this.compressCheck.Enabled = false;
			this.compressCheck.Location = new System.Drawing.Point(12, 165);
			this.compressCheck.Name = "compressCheck";
			this.compressCheck.Size = new System.Drawing.Size(62, 19);
			this.compressCheck.TabIndex = 7;
			this.compressCheck.Text = "再圧縮";
			this.compressCheck.UseVisualStyleBackColor = true;
			// 
			// cleanupWorkDirCheck
			// 
			this.cleanupWorkDirCheck.AutoSize = true;
			this.cleanupWorkDirCheck.Enabled = false;
			this.cleanupWorkDirCheck.Location = new System.Drawing.Point(12, 190);
			this.cleanupWorkDirCheck.Name = "cleanupWorkDirCheck";
			this.cleanupWorkDirCheck.Size = new System.Drawing.Size(86, 19);
			this.cleanupWorkDirCheck.TabIndex = 8;
			this.cleanupWorkDirCheck.Text = "クリーンアップ";
			this.cleanupWorkDirCheck.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(161, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 15);
			this.label3.TabIndex = 9;
			this.label3.Text = "処理数：";
			// 
			// counter
			// 
			this.counter.AutoSize = true;
			this.counter.Location = new System.Drawing.Point(222, 72);
			this.counter.Name = "counter";
			this.counter.Size = new System.Drawing.Size(54, 15);
			this.counter.TabIndex = 10;
			this.counter.Text = "999 / 999";
			// 
			// statProgress
			// 
			this.statProgress.Location = new System.Drawing.Point(12, 29);
			this.statProgress.Name = "statProgress";
			this.statProgress.Size = new System.Drawing.Size(264, 11);
			this.statProgress.TabIndex = 11;
			// 
			// logText
			// 
			this.logText.Location = new System.Drawing.Point(116, 90);
			this.logText.Name = "logText";
			this.logText.ReadOnly = true;
			this.logText.Size = new System.Drawing.Size(160, 94);
			this.logText.TabIndex = 12;
			this.logText.Text = "";
			// 
			// closeButton
			// 
			this.closeButton.Enabled = false;
			this.closeButton.Location = new System.Drawing.Point(116, 185);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(160, 23);
			this.closeButton.TabIndex = 13;
			this.closeButton.Text = "閉じる";
			this.closeButton.UseVisualStyleBackColor = true;
			// 
			// Exec
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(288, 220);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.logText);
			this.Controls.Add(this.statProgress);
			this.Controls.Add(this.counter);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cleanupWorkDirCheck);
			this.Controls.Add(this.compressCheck);
			this.Controls.Add(this.convertCheck);
			this.Controls.Add(this.unZipCheck);
			this.Controls.Add(this.initializeCheck);
			this.Controls.Add(this.wkKey);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.ttlProgress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Exec";
			this.ShowInTaskbar = false;
			this.Text = "Exec";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ProgressBar ttlProgress;
		private TextBox textBox1;
		private Label label1;
		private Label wkKey;
		private CheckBox initializeCheck;
		private CheckBox unZipCheck;
		private CheckBox convertCheck;
		private CheckBox compressCheck;
		private CheckBox cleanupWorkDirCheck;
		private Label label3;
		private Label counter;
		private ProgressBar statProgress;
		private RichTextBox logText;
		private Button closeButton;
	}
}