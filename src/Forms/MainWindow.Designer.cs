namespace LevelScriptEditor.Forms
{
	partial class MainWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsShowEmptyLevelsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsShowEmptyNpcsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsShowCompleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.npcScriptTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.npcImageTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.npcDescTextBox = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1089, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.openToolStripMenuItem.Tag = "";
			this.openToolStripMenuItem.Text = "&Open Directory";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// reloadToolStripMenuItem
			// 
			this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
			this.reloadToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.reloadToolStripMenuItem.Text = "Reload Level";
			this.reloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItem_Click);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(243, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.exitToolStripMenuItem.Text = "E&xit";
			// 
			// optionsStripMenuItem
			// 
			this.optionsStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsShowEmptyLevelsMenuItem,
            this.optionsShowEmptyNpcsMenuItem,
            this.optionsShowCompleteMenuItem});
			this.optionsStripMenuItem.Name = "optionsStripMenuItem";
			this.optionsStripMenuItem.Size = new System.Drawing.Size(75, 24);
			this.optionsStripMenuItem.Text = "&Options";
			// 
			// optionsShowEmptyLevelsMenuItem
			// 
			this.optionsShowEmptyLevelsMenuItem.CheckOnClick = true;
			this.optionsShowEmptyLevelsMenuItem.Name = "optionsShowEmptyLevelsMenuItem";
			this.optionsShowEmptyLevelsMenuItem.Size = new System.Drawing.Size(266, 26);
			this.optionsShowEmptyLevelsMenuItem.Text = "Show Levels with no NPCs";
			this.optionsShowEmptyLevelsMenuItem.CheckedChanged += new System.EventHandler(this.OptionsShowEmptyLevelsMenuItem_CheckedChanged);
			// 
			// optionsShowEmptyNpcsMenuItem
			// 
			this.optionsShowEmptyNpcsMenuItem.CheckOnClick = true;
			this.optionsShowEmptyNpcsMenuItem.Name = "optionsShowEmptyNpcsMenuItem";
			this.optionsShowEmptyNpcsMenuItem.Size = new System.Drawing.Size(266, 26);
			this.optionsShowEmptyNpcsMenuItem.Text = "Show NPCs with no script";
			this.optionsShowEmptyNpcsMenuItem.CheckedChanged += new System.EventHandler(this.optionsShowEmptyNpcsMenuItem_CheckedChanged);
			// 
			// optionsShowCompleteMenuItem
			// 
			this.optionsShowCompleteMenuItem.Checked = true;
			this.optionsShowCompleteMenuItem.CheckOnClick = true;
			this.optionsShowCompleteMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.optionsShowCompleteMenuItem.Name = "optionsShowCompleteMenuItem";
			this.optionsShowCompleteMenuItem.Size = new System.Drawing.Size(266, 26);
			this.optionsShowCompleteMenuItem.Text = "Show Completed NPCS";
			this.optionsShowCompleteMenuItem.CheckedChanged += new System.EventHandler(this.OptionsShowCompletedMenuItem_CheckedChanged);
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(12, 44);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(270, 733);
			this.treeView1.TabIndex = 1;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
			this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeView1_MouseDown);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 780);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1089, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 16);
			// 
			// npcScriptTextBox
			// 
			this.npcScriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.npcScriptTextBox.Location = new System.Drawing.Point(288, 77);
			this.npcScriptTextBox.Multiline = true;
			this.npcScriptTextBox.Name = "npcScriptTextBox";
			this.npcScriptTextBox.Size = new System.Drawing.Size(788, 700);
			this.npcScriptTextBox.TabIndex = 5;
			this.npcScriptTextBox.TextChanged += new System.EventHandler(this.NpcScriptTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(288, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Image";
			// 
			// npcImageTextBox
			// 
			this.npcImageTextBox.Location = new System.Drawing.Point(345, 44);
			this.npcImageTextBox.Name = "npcImageTextBox";
			this.npcImageTextBox.Size = new System.Drawing.Size(256, 27);
			this.npcImageTextBox.TabIndex = 7;
			this.npcImageTextBox.TextChanged += new System.EventHandler(this.NpcImageTextBox_TextChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(607, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "Description";
			// 
			// npcDescTextBox
			// 
			this.npcDescTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.npcDescTextBox.Location = new System.Drawing.Point(698, 44);
			this.npcDescTextBox.MinimumSize = new System.Drawing.Size(128, 4);
			this.npcDescTextBox.Name = "npcDescTextBox";
			this.npcDescTextBox.Size = new System.Drawing.Size(378, 27);
			this.npcDescTextBox.TabIndex = 9;
			this.npcDescTextBox.TextChanged += new System.EventHandler(this.NpcDescTextBox_TextChanged);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1089, 802);
			this.Controls.Add(this.npcDescTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.npcImageTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.npcScriptTextBox);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.menuStrip1);
			this.MinimumSize = new System.Drawing.Size(18, 256);
			this.Name = "MainWindow";
			this.Text = "Quick Script Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TextBox npcScriptTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox npcImageTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox npcDescTextBox;
		private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem optionsStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsShowEmptyLevelsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsShowCompleteMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsShowEmptyNpcsMenuItem;
	}
}

