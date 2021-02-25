using LevelScriptEditor.State;
using LevelScriptEditor.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LevelScriptEditor.Forms
{
	public partial class MainWindow : Form
	{
		private readonly GlobalState state = new GlobalState();
		private LevelNPCNode activeNode = null;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void TreeView1_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			switch (e.Node.Level)
			{
				// Level node
				case 0:
				{
					var node = (LevelNode)e.Node;
					if (node.GameLevel == null)
					{
						node.Load();
						if (e.Action != TreeViewAction.ByKeyboard)
							node.Expand();
					}

					break;
				}

				// NPC node
				case 1:
					SetActiveNode((LevelNPCNode)e.Node);
					break;
			}
		}

		private void TreeView1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
				return;

			TreeNode node_here = treeView1.GetNodeAt(e.X, e.Y);
			treeView1.SelectedNode = node_here;

			if (node_here != null)
			{
				switch (node_here.Level)
				{
					// Level node
					case 0:
						ShowContextMenu((LevelNode)node_here, e);
						break;

					// NPC node
					case 1:
						ShowContextMenu((LevelNPCNode)node_here, e);
						break;
				}
			}
		}

		private void ShowContextMenu(LevelNode node, MouseEventArgs e)
		{
			//var contextMenuStrip = new ContextMenuStrip();
		}

		private void ShowContextMenu(LevelNPCNode node, MouseEventArgs e)
		{
			var contextMenuStrip = new ContextMenuStrip();

			///////////
			{
				var marked = node.NPC.Headers.ContainsKey("MARKED");

				ToolStripMenuItem markLabel = new ToolStripMenuItem();
				markLabel.Text = (marked ? "Unmark Complete" : "Mark Complete");
				markLabel.Click += new EventHandler((s, e) =>
				{
					node.NPC.ToggleHeader("MARKED");
					RedrawLevelNode((LevelNode)node.Parent);
				});
				contextMenuStrip.Items.Add(markLabel);
			}

			{
				ToolStripMenuItem replaceLabel = new ToolStripMenuItem();
				replaceLabel.Text = "Replace similar scripts";
				replaceLabel.Click += new EventHandler((s, e) =>
				{
					using (var diag = new ReplaceScriptsForm(state, node))
					{
						var result = diag.ShowDialog();
						if (result == DialogResult.OK)
						{
							// clear the current node to prevent overwriting changes
							activeNode = null;
							SetActiveNode(node);
							
							treeView1.BeginUpdate();
							foreach (var item in state.npcChangeList)
								item.UpdateDescription();
							treeView1.EndUpdate();

							RedrawNodes();
						}
					}
				});
				contextMenuStrip.Items.Add(replaceLabel);
			}

			contextMenuStrip.Show(treeView1, e.Location);
		}

		#region Update NPC Scripts
		private void SetActiveNode(LevelNPCNode node)
		{
			// Save current node changes
			if (activeNode != null)
				UpdateActiveNode();
			
			// Clear fields
			npcDescTextBox.Clear();
			npcImageTextBox.Clear();
			npcScriptTextBox.Clear();

			// Set new node
			activeNode = node;
			if (node != null)
			{
				npcDescTextBox.Text = node.NPC.Headers.GetValueOrDefault("DESC", string.Empty);
				npcImageTextBox.Text = node.NPC.Image;
				npcScriptTextBox.Text = node.NPC.Code.Replace("\n", "\r\n");
			}
		}

		private void UpdateActiveNode()
		{
			if (activeNode != null)
			{
				state.UpdateNPC(activeNode,
					npcScriptTextBox.Text.Replace("\r\n", "\n"),
					npcImageTextBox.Text.Trim(),
					npcDescTextBox.Text.Trim(),
					null);
			}
		}

		private void SetStatusDescription(string text)
		{
			toolStripStatusLabel1.Text = text;
		}

		private void NpcDescTextBox_TextChanged(object sender, EventArgs e)
		{
			var s = (TextBox)sender;
			if (s.Modified)
			{
				UpdateActiveNode();
				if (activeNode != null)
					activeNode.UpdateDescription();
			}
		}

		private void NpcScriptTextBox_TextChanged(object sender, EventArgs e)
		{
			var s = (TextBox)sender;
			if (s.Modified)
				UpdateActiveNode();
		}

		private void NpcImageTextBox_TextChanged(object sender, EventArgs e)
		{
			var s = (TextBox)sender;
			if (s.Modified)
				UpdateActiveNode();
		}
		#endregion

		#region Toolbar Options
		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					// TODO(joey): are you sure you want to discard changes?

					// reset state
					SetActiveNode(null);
					state.nodeList.Clear();
					state.levelChangeList.Clear();
					state.npcChangeList.Clear();
					treeView1.Nodes.Clear();

					state.baseDir = fbd.SelectedPath;
					string[] files = Directory.GetFiles(state.baseDir, "*.nw").Select(file => Path.GetFileName(file)).ToArray();

					if (files.Length > 0)
					{
						// create nodes
						foreach (string file in files)
							state.nodeList.Add(new LevelNode(state.baseDir, file));

						// read all levels
						foreach (LevelNode node in state.nodeList)
							node.Load();

						// sort the nodes (may move into RedrawNodes)
						state.nodeList.Sort(new LevelNodeSorter());

						RedrawNodes();
						SetStatusDescription(string.Format("Loaded folder {0} with {1} levels", state.baseDir, files.Length));
					}
					else SetStatusDescription(string.Format("No levels found in {0}", state.baseDir));
				}
			}
		}

		private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (activeNode != null)
			{
				var parentNode = (LevelNode)activeNode.Parent;
				if (parentNode != null)
				{
					try
					{
						parentNode.Load();
						SetStatusDescription(string.Format("Reloaded level {0} successfully.", parentNode.GameLevel.Name));
					}
					catch (Exception ex)
					{
						SetStatusDescription(string.Format("Error reloading level {0}, exception received: {1}", parentNode.GameLevel.Name, ex.Message));
					}
				}

				SetActiveNode((LevelNPCNode)parentNode.FirstNode);
			}
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var levelsModified = state.levelChangeList.Count;

			if (levelsModified > 0)
			{
				try
				{
					// Form the status messages before issueing SaveLevels since it will clear the list
					string msg;
					if (levelsModified > 1)
					{
						msg = string.Format("Saved changes for {0} npcs in {1} levels successfully.", state.npcChangeList.Count, levelsModified);
					}
					else
					{
						msg = string.Format("Saved level {0} successfully.", state.levelChangeList.First().Name);
					}

					// Save level-change-list
					state.SaveLevels();

					SetStatusDescription(msg);
				}
				catch (Exception ex)
				{
					SetStatusDescription(string.Format("Error saving level(s), exception received: {0}", ex.Message));
				}
			}
		}
		private void OptionsShowEmptyLevelsMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			state.showEmptyLevels = optionsShowEmptyLevelsMenuItem.Checked;
			RedrawNodes();
		}

		private void OptionsShowCompletedMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			state.showCompletedNpcs = optionsShowCompleteMenuItem.Checked;
			RedrawNodes();
		}

		private void OptionsShowEmptyNpcsMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			state.showEmptyNpcs = optionsShowEmptyNpcsMenuItem.Checked;
			RedrawNodes();
		}

		private void OptionReplaceMatchImagesMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			state.matchImageNames = optionReplaceMatchImagesMenuItem.Checked;
		}
		#endregion

		#region Script filtering
		private Timer m_delayedTextChangedTimer;
		private string m_searchText;

		private void SearchBox_DelayTimer(object sender, EventArgs e)
		{
			((Timer)sender).Stop();
			RedrawNodes();
		}

		private void SearchBox_TextChanged(object sender, EventArgs e)
		{
			var s = (TextBox)sender;
			if (s.Modified)
			{
				if (m_delayedTextChangedTimer != null)
					m_delayedTextChangedTimer.Stop();

				m_delayedTextChangedTimer = new Timer();
				m_delayedTextChangedTimer.Interval = 1000;
				m_delayedTextChangedTimer.Tick += SearchBox_DelayTimer;
				m_delayedTextChangedTimer.Start();
			}
		}
		#endregion

		private void RedrawNodes()
		{
			var nodes = state.nodeList.AsEnumerable();

			if (!state.showEmptyLevels)
				nodes = nodes.Where(n => n.ChildrenNodes.Count > 0);

			m_searchText = searchBox.Text.Replace("\r\n", "\n");

			treeView1.Nodes.Clear();
			treeView1.BeginUpdate();

			foreach (var n in nodes)
			{
				RedrawLevelNode(n);
				if (n.Nodes.Count > 0)
					treeView1.Nodes.Add(n);
			}

			treeView1.EndUpdate();

			// Try to preserve the current position in the treeview
			if (activeNode != null && activeNode.Parent != null)
			{
				if (activeNode.Parent.LastNode != null)
					activeNode.Parent.LastNode.EnsureVisible();
				else
					activeNode.Parent.EnsureVisible();
				activeNode.EnsureVisible();
			}
		}

		private void RedrawLevelNode(LevelNode node)
		{
			var childNodes = node.ChildrenNodes.AsEnumerable();

			if (!state.showCompletedNpcs)
				childNodes = childNodes.Where(n => !n.NPC.Headers.ContainsKey("MARKED"));

			if (!state.showEmptyNpcs)
				childNodes = childNodes.Where(n => n.NPC.Code.Trim().Length > 0);

			if (m_searchText.Length > 0)
				childNodes = childNodes.Where(n => n.NPC.Code.Contains(m_searchText));

			node.Nodes.Clear();
			node.Nodes.AddRange(childNodes.ToArray());
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			var modFileCount = state.levelChangeList.Count;

			if (modFileCount > 0)
			{
				var window = MessageBox.Show("You still have " + modFileCount.ToString() + " levels with unsaved changes! Click No, and save your changes!", "Close the application without saving?", MessageBoxButtons.YesNo);
				e.Cancel = (window == DialogResult.No);
			}
		}
	}
}
