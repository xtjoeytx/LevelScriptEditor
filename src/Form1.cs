using LevelScriptEditor.UI;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LevelScriptEditor
{
	public partial class Form1 : Form
	{
		private string baseDir = "";
		private LevelNPCNode activeNode = null;

		public Form1()
		{
			InitializeComponent();

			npcScriptTextBox.AcceptsReturn = true;
			npcScriptTextBox.AcceptsTab = true;
			npcScriptTextBox.ScrollBars = ScrollBars.Vertical;
		}

		private void TreeView1_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			switch (e.Node.Level)
			{
				// Level node
				case 0:
				{
					var node = (LevelNode)e.Node;
					if (!node.Loaded)
					{
						node.Load();
						if (e.Action != TreeViewAction.ByKeyboard)
							node.Expand();
					}

					break;
				}

				// NPC node
				case 1:
				{
					var node = (LevelNPCNode)e.Node;
					setActiveNode(node);
					break;
				}
			}
		}

		private void updateActiveNode()
		{
			if (activeNode != null)
			{
				activeNode.NPC.Code = npcScriptTextBox.Text.Replace("\r\n", "\n");
				activeNode.NPC.Description = npcDescTextBox.Text.Trim();
				activeNode.NPC.Image = npcImageTextBox.Text.Trim();
			}
		}

		private void setActiveNode(LevelNPCNode node)
		{
			// Save current node changes
			if (activeNode != null)
				updateActiveNode();

			// Clear fields
			npcDescTextBox.Clear();
			npcImageTextBox.Clear();
			npcScriptTextBox.Clear();

			// Set new node
			activeNode = node;
			if (node != null)
			{
				npcDescTextBox.Text = node.NPC.Description;
				npcImageTextBox.Text = node.NPC.Image;
				npcScriptTextBox.Text = node.NPC.Code.Replace("\n", "\r\n");
			}
		}

		private void setStatusDescription(string text)
		{
			toolStripStatusLabel1.Text = text;
		}

		private void npcDescTextBox_TextChanged(object sender, EventArgs e)
		{
			var s = (TextBox)sender;
			if (s.Modified)
			{
				updateActiveNode();
				if (activeNode != null)
					activeNode.UpdateDescription();
			}
		}

		private void npcScriptTextBox_TextChanged(object sender, EventArgs e)
		{
			var s = (TextBox)sender;
			if (s.Modified)
				updateActiveNode();
		}

		private void npcImageTextBox_TextChanged(object sender, EventArgs e)
		{
			var s = (TextBox)sender;
			if (s.Modified)
				updateActiveNode();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					setActiveNode(null);
					treeView1.Nodes.Clear();

					baseDir = fbd.SelectedPath;
					string[] files = Directory.GetFiles(baseDir, "*.nw").Select(file => Path.GetFileName(file)).ToArray();

					if (files.Length > 0)
					{
						treeView1.BeginUpdate();
						foreach (string file in files)
							treeView1.Nodes.Add(new LevelNode(baseDir, file));
						treeView1.EndUpdate();

						setStatusDescription(string.Format("Loaded folder {0} with {1} levels", baseDir, files.Length));
					}
					else setStatusDescription(string.Format("No levels found in {0}", baseDir));
				}
			}
		}

		private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (activeNode != null)
			{
				var parentNode = (LevelNode)activeNode.Parent;
				if (parentNode != null)
				{
					try
					{
						parentNode.Load();
						setStatusDescription(string.Format("Reloaded level {0} successfully.", parentNode.GameLevel.Name));
					}
					catch (Exception ex)
					{
						setStatusDescription(string.Format("Error reloading level {0}, exception received: {1}", parentNode.GameLevel.Name, ex.Message));
					}
				}

				setActiveNode((LevelNPCNode)parentNode.FirstNode);
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (activeNode != null)
			{
				var parentNode = (LevelNode)activeNode.Parent;
				if (parentNode != null)
				{
					try
					{
						parentNode.Save();
						setStatusDescription(string.Format("Saved level {0} successfully.", parentNode.GameLevel.Name));
					}
					catch (Exception ex)
					{
						setStatusDescription(string.Format("Error saving level {0}, exception received: {1}", parentNode.GameLevel.Name, ex.Message));
					}
				}
			}
		}
	}
}
