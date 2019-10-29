namespace App_Type_v2
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.MainStatus = new System.Windows.Forms.StatusStrip();
			this.SpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ScoreLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.HighscoreLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.PlaytimetoolStrip = new System.Windows.Forms.ToolStripStatusLabel();
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.totalTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.totalCollectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.acctuaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.totalClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.totalScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TotalPlaytimetoolStrip = new System.Windows.Forms.ToolStripMenuItem();
			this.TypeSpeedtoolStrip = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.clearStatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.RemainTimeBar = new System.Windows.Forms.PictureBox();
			this.DrawTimer = new System.Windows.Forms.Timer(this.components);
			this.MainLabel = new System.Windows.Forms.Label();
			this.CaptionLabel = new System.Windows.Forms.Label();
			this.InputLabel = new System.Windows.Forms.Label();
			this.RemainTimeLabel = new System.Windows.Forms.Label();
			this.MainTick = new System.Windows.Forms.Timer(this.components);
			this.ReadyCounter = new System.Windows.Forms.Timer(this.components);
			this.MainStatus.SuspendLayout();
			this.MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RemainTimeBar)).BeginInit();
			this.SuspendLayout();
			// 
			// MainStatus
			// 
			this.MainStatus.BackColor = System.Drawing.Color.Transparent;
			this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SpeedLabel,
            this.ScoreLabel,
            this.HighscoreLabel,
            this.PlaytimetoolStrip});
			this.MainStatus.Location = new System.Drawing.Point(0, 458);
			this.MainStatus.Name = "MainStatus";
			this.MainStatus.Size = new System.Drawing.Size(960, 22);
			this.MainStatus.TabIndex = 0;
			this.MainStatus.Text = "statusStrip1";
			// 
			// SpeedLabel
			// 
			this.SpeedLabel.AutoSize = false;
			this.SpeedLabel.Name = "SpeedLabel";
			this.SpeedLabel.Size = new System.Drawing.Size(100, 17);
			this.SpeedLabel.Text = "Speed";
			this.SpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ScoreLabel
			// 
			this.ScoreLabel.AutoSize = false;
			this.ScoreLabel.Name = "ScoreLabel";
			this.ScoreLabel.Size = new System.Drawing.Size(120, 17);
			this.ScoreLabel.Text = "SCORE";
			this.ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// HighscoreLabel
			// 
			this.HighscoreLabel.AutoSize = false;
			this.HighscoreLabel.Name = "HighscoreLabel";
			this.HighscoreLabel.Size = new System.Drawing.Size(150, 17);
			this.HighscoreLabel.Text = "HIGHSCORE";
			this.HighscoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PlaytimetoolStrip
			// 
			this.PlaytimetoolStrip.Name = "PlaytimetoolStrip";
			this.PlaytimetoolStrip.Size = new System.Drawing.Size(54, 17);
			this.PlaytimetoolStrip.Text = "Playtime";
			// 
			// MainMenu
			// 
			this.MainMenu.BackColor = System.Drawing.Color.LightSteelBlue;
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.statToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem1});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(960, 24);
			this.MainMenu.TabIndex = 1;
			this.MainMenu.Text = "menuStrip1";
			this.MainMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainMenu_MouseDown);
			// 
			// mainToolStripMenuItem
			// 
			this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.mainToolStripMenuItem.MergeIndex = 0;
			this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
			this.mainToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.mainToolStripMenuItem.Text = "Main";
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.startToolStripMenuItem.Text = "Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.resetToolStripMenuItem.Text = "Reset";
			this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(103, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// statToolStripMenuItem
			// 
			this.statToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalTypeToolStripMenuItem,
            this.totalCollectToolStripMenuItem,
            this.acctuaryToolStripMenuItem,
            this.totalClearToolStripMenuItem,
            this.totalScoreToolStripMenuItem,
            this.TotalPlaytimetoolStrip,
            this.TypeSpeedtoolStrip,
            this.toolStripSeparator2,
            this.clearStatToolStripMenuItem});
			this.statToolStripMenuItem.MergeIndex = 1;
			this.statToolStripMenuItem.Name = "statToolStripMenuItem";
			this.statToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.statToolStripMenuItem.Text = "Stat";
			// 
			// totalTypeToolStripMenuItem
			// 
			this.totalTypeToolStripMenuItem.Enabled = false;
			this.totalTypeToolStripMenuItem.Name = "totalTypeToolStripMenuItem";
			this.totalTypeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.totalTypeToolStripMenuItem.Text = "TotalType";
			// 
			// totalCollectToolStripMenuItem
			// 
			this.totalCollectToolStripMenuItem.Enabled = false;
			this.totalCollectToolStripMenuItem.Name = "totalCollectToolStripMenuItem";
			this.totalCollectToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.totalCollectToolStripMenuItem.Text = "TotalCollect";
			// 
			// acctuaryToolStripMenuItem
			// 
			this.acctuaryToolStripMenuItem.Enabled = false;
			this.acctuaryToolStripMenuItem.Name = "acctuaryToolStripMenuItem";
			this.acctuaryToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.acctuaryToolStripMenuItem.Text = "Acctuary";
			// 
			// totalClearToolStripMenuItem
			// 
			this.totalClearToolStripMenuItem.Enabled = false;
			this.totalClearToolStripMenuItem.Name = "totalClearToolStripMenuItem";
			this.totalClearToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.totalClearToolStripMenuItem.Text = "TotalClear";
			// 
			// totalScoreToolStripMenuItem
			// 
			this.totalScoreToolStripMenuItem.Enabled = false;
			this.totalScoreToolStripMenuItem.Name = "totalScoreToolStripMenuItem";
			this.totalScoreToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.totalScoreToolStripMenuItem.Text = "TotalScore";
			// 
			// TotalPlaytimetoolStrip
			// 
			this.TotalPlaytimetoolStrip.Enabled = false;
			this.TotalPlaytimetoolStrip.Name = "TotalPlaytimetoolStrip";
			this.TotalPlaytimetoolStrip.Size = new System.Drawing.Size(149, 22);
			this.TotalPlaytimetoolStrip.Text = "TotalPlaytime";
			// 
			// TypeSpeedtoolStrip
			// 
			this.TypeSpeedtoolStrip.Enabled = false;
			this.TypeSpeedtoolStrip.Name = "TypeSpeedtoolStrip";
			this.TypeSpeedtoolStrip.Size = new System.Drawing.Size(149, 22);
			this.TypeSpeedtoolStrip.Text = "TypeSpeed";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
			// 
			// clearStatToolStripMenuItem
			// 
			this.clearStatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
			this.clearStatToolStripMenuItem.Name = "clearStatToolStripMenuItem";
			this.clearStatToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.clearStatToolStripMenuItem.Text = "ClearStat";
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
			this.clearToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.MergeIndex = 2;
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// versionToolStripMenuItem
			// 
			this.versionToolStripMenuItem.Enabled = false;
			this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
			this.versionToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.versionToolStripMenuItem.Text = "Version";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem1
			// 
			this.exitToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			this.exitToolStripMenuItem1.Size = new System.Drawing.Size(41, 20);
			this.exitToolStripMenuItem1.Text = "Exit";
			this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// RemainTimeBar
			// 
			this.RemainTimeBar.BackColor = System.Drawing.Color.Transparent;
			this.RemainTimeBar.BackgroundImage = global::App_Type_v2.Properties.Resources.line;
			this.RemainTimeBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.RemainTimeBar.Location = new System.Drawing.Point(0, 350);
			this.RemainTimeBar.Name = "RemainTimeBar";
			this.RemainTimeBar.Size = new System.Drawing.Size(10, 5);
			this.RemainTimeBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.RemainTimeBar.TabIndex = 2;
			this.RemainTimeBar.TabStop = false;
			// 
			// DrawTimer
			// 
			this.DrawTimer.Interval = 20;
			this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
			// 
			// MainLabel
			// 
			this.MainLabel.AutoSize = true;
			this.MainLabel.BackColor = System.Drawing.Color.Transparent;
			this.MainLabel.Font = new System.Drawing.Font("游ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MainLabel.Location = new System.Drawing.Point(12, 96);
			this.MainLabel.Name = "MainLabel";
			this.MainLabel.Size = new System.Drawing.Size(147, 35);
			this.MainLabel.TabIndex = 3;
			this.MainLabel.Text = "MainLabel";
			// 
			// CaptionLabel
			// 
			this.CaptionLabel.AutoSize = true;
			this.CaptionLabel.BackColor = System.Drawing.Color.Transparent;
			this.CaptionLabel.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.CaptionLabel.Location = new System.Drawing.Point(17, 138);
			this.CaptionLabel.Name = "CaptionLabel";
			this.CaptionLabel.Size = new System.Drawing.Size(108, 21);
			this.CaptionLabel.TabIndex = 4;
			this.CaptionLabel.Text = "CaptionLabel";
			// 
			// InputLabel
			// 
			this.InputLabel.AutoSize = true;
			this.InputLabel.BackColor = System.Drawing.Color.Transparent;
			this.InputLabel.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.InputLabel.Location = new System.Drawing.Point(19, 159);
			this.InputLabel.Name = "InputLabel";
			this.InputLabel.Size = new System.Drawing.Size(68, 16);
			this.InputLabel.TabIndex = 5;
			this.InputLabel.Text = "InputLabel";
			// 
			// RemainTimeLabel
			// 
			this.RemainTimeLabel.AutoSize = true;
			this.RemainTimeLabel.BackColor = System.Drawing.Color.Transparent;
			this.RemainTimeLabel.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.RemainTimeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.RemainTimeLabel.Location = new System.Drawing.Point(12, 326);
			this.RemainTimeLabel.Name = "RemainTimeLabel";
			this.RemainTimeLabel.Size = new System.Drawing.Size(103, 21);
			this.RemainTimeLabel.TabIndex = 6;
			this.RemainTimeLabel.Text = "RemainTime";
			// 
			// MainTick
			// 
			this.MainTick.Tick += new System.EventHandler(this.MainTick_Tick);
			// 
			// ReadyCounter
			// 
			this.ReadyCounter.Interval = 1000;
			this.ReadyCounter.Tick += new System.EventHandler(this.ReadyCounter_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::App_Type_v2.Properties.Resources.App_Type_BG_2;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(960, 480);
			this.Controls.Add(this.RemainTimeLabel);
			this.Controls.Add(this.InputLabel);
			this.Controls.Add(this.CaptionLabel);
			this.Controls.Add(this.MainLabel);
			this.Controls.Add(this.RemainTimeBar);
			this.Controls.Add(this.MainStatus);
			this.Controls.Add(this.MainMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.MainMenu;
			this.MaximumSize = new System.Drawing.Size(960, 480);
			this.MinimumSize = new System.Drawing.Size(960, 480);
			this.Name = "MainForm";
			this.Text = "App_Type_MainForm";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.MainStatus.ResumeLayout(false);
			this.MainStatus.PerformLayout();
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RemainTimeBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip MainStatus;
		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
		private System.Windows.Forms.PictureBox RemainTimeBar;
		private System.Windows.Forms.Timer DrawTimer;
		private System.Windows.Forms.Label MainLabel;
		private System.Windows.Forms.Label CaptionLabel;
		private System.Windows.Forms.Label InputLabel;
		private System.Windows.Forms.Label RemainTimeLabel;
		private System.Windows.Forms.Timer MainTick;
		private System.Windows.Forms.Timer ReadyCounter;
		private System.Windows.Forms.ToolStripStatusLabel SpeedLabel;
		private System.Windows.Forms.ToolStripStatusLabel ScoreLabel;
		private System.Windows.Forms.ToolStripStatusLabel HighscoreLabel;
		private System.Windows.Forms.ToolStripMenuItem statToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem totalTypeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem totalCollectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem acctuaryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem totalClearToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem totalScoreToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem clearStatToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel PlaytimetoolStrip;
		private System.Windows.Forms.ToolStripMenuItem TotalPlaytimetoolStrip;
		private System.Windows.Forms.ToolStripMenuItem TypeSpeedtoolStrip;
	}
}

