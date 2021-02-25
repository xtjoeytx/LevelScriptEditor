using System;
using Gdk;
using Gtk;

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
			/*
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
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.optionsReplaceStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionReplaceMatchImagesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			*/
			this.treeView1 = new NodeView();
			/*
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.npcScriptTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.npcImageTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.npcDescTextBox = new System.Windows.Forms.TextBox();
			this.searchBox = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new ToolStripItem[] {
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
			this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
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
			this.openToolStripMenuItem.ShortcutKeys = ((Keys)((Keys.Control | Keys.O)));
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
			this.saveToolStripMenuItem.ShortcutKeys = ((Keys)((Keys.Control | Keys.S)));
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
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// optionsStripMenuItem
			// 
			this.optionsStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.optionsShowEmptyLevelsMenuItem,
            this.optionsShowEmptyNpcsMenuItem,
            this.optionsShowCompleteMenuItem,
            this.toolStripSeparator2,
            this.optionsReplaceStripMenuItem});
			this.optionsStripMenuItem.Name = "optionsStripMenuItem";
			this.optionsStripMenuItem.Size = new System.Drawing.Size(75, 24);
			this.optionsStripMenuItem.Text = "&Options";
			// 
			// optionsShowEmptyLevelsMenuItem
			// 
			this.optionsShowEmptyLevelsMenuItem.CheckOnClick = true;
			this.optionsShowEmptyLevelsMenuItem.Name = "optionsShowEmptyLevelsMenuItem";
			this.optionsShowEmptyLevelsMenuItem.Size = new System.Drawing.Size(263, 26);
			this.optionsShowEmptyLevelsMenuItem.Text = "Show Levels with no NPCs";
			this.optionsShowEmptyLevelsMenuItem.CheckedChanged += new System.EventHandler(this.OptionsShowEmptyLevelsMenuItem_CheckedChanged);
			// 
			// optionsShowEmptyNpcsMenuItem
			// 
			this.optionsShowEmptyNpcsMenuItem.CheckOnClick = true;
			this.optionsShowEmptyNpcsMenuItem.Name = "optionsShowEmptyNpcsMenuItem";
			this.optionsShowEmptyNpcsMenuItem.Size = new System.Drawing.Size(263, 26);
			this.optionsShowEmptyNpcsMenuItem.Text = "Show NPCs with no script";
			this.optionsShowEmptyNpcsMenuItem.CheckedChanged += new System.EventHandler(this.OptionsShowEmptyNpcsMenuItem_CheckedChanged);
			// 
			// optionsShowCompleteMenuItem
			// 
			this.optionsShowCompleteMenuItem.Checked = true;
			this.optionsShowCompleteMenuItem.CheckOnClick = true;
			this.optionsShowCompleteMenuItem.CheckState = CheckState.Checked;
			this.optionsShowCompleteMenuItem.Name = "optionsShowCompleteMenuItem";
			this.optionsShowCompleteMenuItem.Size = new System.Drawing.Size(263, 26);
			this.optionsShowCompleteMenuItem.Text = "Show Completed NPCS";
			this.optionsShowCompleteMenuItem.CheckedChanged += new System.EventHandler(this.OptionsShowCompletedMenuItem_CheckedChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(260, 6);
			// 
			// optionsReplaceStripMenuItem
			// 
			this.optionsReplaceStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionReplaceMatchImagesMenuItem});
			this.optionsReplaceStripMenuItem.Name = "optionsReplaceStripMenuItem";
			this.optionsReplaceStripMenuItem.Size = new System.Drawing.Size(263, 26);
			this.optionsReplaceStripMenuItem.Text = "Replace Scripts";
			// 
			// optionReplaceMatchImagesMenuItem
			// 
			this.optionReplaceMatchImagesMenuItem.Checked = true;
			this.optionReplaceMatchImagesMenuItem.CheckOnClick = true;
			this.optionReplaceMatchImagesMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.optionReplaceMatchImagesMenuItem.Name = "optionReplaceMatchImagesMenuItem";
			this.optionReplaceMatchImagesMenuItem.Size = new System.Drawing.Size(229, 26);
			this.optionReplaceMatchImagesMenuItem.Text = "Match Image Names";
			this.optionReplaceMatchImagesMenuItem.CheckedChanged += new System.EventHandler(this.OptionReplaceMatchImagesMenuItem_CheckedChanged);
			*/
			// 
			// treeView1
			// 
			//this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//            | System.Windows.Forms.AnchorStyles.Left)));			this.treeView1.Location = new System.Drawing.Point(12, 44);
			this.treeView1.Name = "treeView1";
			this.treeView1.SetSizeRequest(270, 632);
			//this.treeView1.TabIndex = 1;
			//this.treeView1.AfterSelect += new TreeViewEventHandler(this.TreeView1_AfterSelect);
			this.treeView1.NodeSelection.Changed += this.TreeView1_AfterSelect;
			//this.treeView1.ButtonPressEvent += this.TreeView1_MouseDown;
			this.treeView1.NodeSelection.Mode = SelectionMode.Single;
			
			//this.treeView1.Sensitive = true; //.ButtonPressEvent += TreeView1_MouseDown;
			this.treeView1.FixedHeightMode = false;
			this.treeView1.HeadersClickable = true;
			this.treeView1.HeadersVisible = true;
			this.treeView1.SearchColumn = 0;
			this.treeView1.EnableSearch = true;
			this.treeView1.EnableTreeLines = true;
			
			//this.treeView1.PopupMenu += TreeView1OnPopupMenu;
			this.treeView1.WidgetEvent += TreeView1_MouseDown;
			this.treeView1.ShowExpanders = true;
			
						
			// Create our TreeView and add it as our child widget
			this.treeView1.NodeStore = Store;

			Dialog test = new Dialog("test", this, DialogFlags.Modal);
			test.SetSizeRequest(800,600);
			test.AddButton("_OK", ResponseType.Ok);
			test.AddButton("_Cancel", ResponseType.Cancel);
			test.DestroyEvent += delegate(object sender, DestroyEventArgs args)
			{
				
			};
			test.ShowAll();
			var column = this.treeView1.AppendColumn ("Levels", new Gtk.CellRendererText (), "text", 0);
			column.SortIndicator = true;
			column.SortOrder = SortType.Ascending;
			column.SortColumnId = 0;
			
			// Create a column with title 'Song Title' and bind its renderer to model column 1
			//treeView1.AppendColumn ("Song Title", new Gtk.CellRendererText (), "text", 1);
			this.treeView1.ShowAll ();
			
			Table table = new Table(2, 1, false);
			
			Table ServersFrameTable = new Table(1, 2, false);
			
			ServersFrameTable.RowSpacing = 1;
			Label spacer = new Label();
			spacer.SetSizeRequest(10, 1);
			ServersFrameTable.Attach(spacer, 0, 1, 0, 1, AttachOptions.Fill, AttachOptions.Fill, 5, 1);

			ScrolledWindow ServerListScrolledWindow = new global::Gtk.ScrolledWindow();
			ServerListScrolledWindow.Name = "GtkScrolledWindow";
			ServerListScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));

			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild

			ServerListScrolledWindow.Add(this.treeView1);
			
			Frame ServerListFrame = new Frame();
			//ServerListFrame.Add(ServerListScrolledWindow);

			Frame ServerInfoFrame = new Frame();

			ServersFrameTable.Attach(ServerInfoFrame, 1, 2, 0, 1, AttachOptions.Fill | AttachOptions.Expand, AttachOptions.Fill | AttachOptions.Expand, 5, 1);
			ServersFrameTable.Attach(ServerListScrolledWindow, 0, 1, 0, 1, AttachOptions.Fill | AttachOptions.Expand, AttachOptions.Fill | AttachOptions.Expand, 5, 1);

			HBox hbox = new HBox(true, 5);
			table.BorderWidth = 0;
			table.SetSizeRequest(100, 100);
			/*
			Frame ServersFrame = new Frame();
			ServersFrame.LabelWidget = new Label() { Name = "Servers", Text = " Servers " };
			ServersFrame.ShadowType = ShadowType.EtchedIn;
			ServersFrame.Add(ServersFrameTable);
			*/
			table.Attach(ServersFrameTable, 0, 1, 0, 1, AttachOptions.Fill | AttachOptions.Expand, AttachOptions.Fill | AttachOptions.Expand, 5, 5);
			this.Add(table);

			/*
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 779);
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
			this.npcScriptTextBox.AcceptsReturn = true;
			this.npcScriptTextBox.AcceptsTab = true;
			this.npcScriptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.npcScriptTextBox.Location = new System.Drawing.Point(288, 77);
			this.npcScriptTextBox.Multiline = true;
			this.npcScriptTextBox.Name = "npcScriptTextBox";
			this.npcScriptTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.npcScriptTextBox.Size = new System.Drawing.Size(788, 699);
			this.npcScriptTextBox.TabIndex = 5;
			this.npcScriptTextBox.TextChanged += new System.EventHandler(this.NpcScriptTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left)));
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
			this.label2.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(607, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "Description";
			// 
			// npcDescTextBox
			// 
			this.npcDescTextBox.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
			this.npcDescTextBox.Location = new System.Drawing.Point(698, 44);
			this.npcDescTextBox.MinimumSize = new System.Drawing.Size(128, 4);
			this.npcDescTextBox.Name = "npcDescTextBox";
			this.npcDescTextBox.Size = new System.Drawing.Size(378, 27);
			this.npcDescTextBox.TabIndex = 9;
			this.npcDescTextBox.TextChanged += new System.EventHandler(this.NpcDescTextBox_TextChanged);
			// 
			// searchBox
			// 
			this.searchBox.AcceptsReturn = true;
			this.searchBox.AcceptsTab = true;
			this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.searchBox.Location = new System.Drawing.Point(13, 682);
			this.searchBox.Multiline = true;
			this.searchBox.Name = "searchBox";
			this.searchBox.Size = new System.Drawing.Size(269, 94);
			this.searchBox.TabIndex = 10;
			this.searchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1089, 801);
			this.Controls.Add(this.searchBox);
			this.Controls.Add(this.npcDescTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.npcImageTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.npcScriptTextBox);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.menuStrip1);
			this.MinimumSize = new System.Drawing.Size(18, 256);
			
			this.FormClosing += new FormClosingEventHandler(this.MainWindow_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
			*/

			
			this.SetDefaultSize(1089,802);
			//this.SetSizeRequest(280, 210);
			//this.DoubleBuffered = true;
			
			this.Name = "MainWindow";
			
			this.SetPosition(Gtk.WindowPosition.Center);
			this.Title = "Quick Script Editor";
			//this.Icon = Pixbuf.LoadFromResource("OpenGraal.RC.Resources.rcicon.ico");
			this.DeleteEvent += MainWindow_FormClosing;

		}

		#endregion
		/*
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		*/
		private NodeView treeView1;
		/*
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
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem optionsReplaceStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionReplaceMatchImagesMenuItem;
		private System.Windows.Forms.TextBox searchBox;
		*/
	}
}

