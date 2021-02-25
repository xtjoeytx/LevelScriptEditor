using LevelScriptEditor.State;
using LevelScriptEditor.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Gdk;
using Gtk;
using LevelScriptEditor.Levels;
using Window = Gtk.Window;
using WindowType = Gtk.WindowType;
using static Gtk.Application;

namespace LevelScriptEditor.Forms
{
	public partial class MainWindow : Window
	{
		private readonly GlobalState state = new GlobalState();
		private UINode activeNode = null;
		private static MainWindow _instance;
		public static MainWindow Instance => _instance ??= new MainWindow();

		private MainWindow() : base(WindowType.Toplevel)
		{
			InitializeComponent();
			OpenToolStripMenuItem_Click(null, null);
		}

		private void TreeView1_AfterSelect(object o, EventArgs args)
		{
			NodeSelection selection = (NodeSelection) o;
			UINode node = (UINode)selection.SelectedNode;
			
			Console.WriteLine($@"Select: {node?.NodeObject?.GetType()}");
			if (node != null)
			{
				switch (node?.NodeObject?.GetType()?.ToString())
				{
					// Level node
					case "LevelScriptEditor.UI.LevelNode":
					{
						
						if (!node.Loaded)
						{
							//node.Load();
							/*
							if (e.Action != TreeViewAction.ByKeyboard)
								node.Expand();
							*/
							
						}

						break;
					}

					// NPC node
					case "LevelScriptEditor.UI.LevelNPCNode":
						SetActiveNode(node);
						break;
				}
			}
		}

		private void TreeView1_MouseDown(object sender, WidgetEventArgs e)
		{
			if ((e.Event is EventButton ev) && (ev.Type == EventType.ButtonPress) && (ev.Window == treeView1.BinWindow))
			{
				
				if (ev.Button != 3)
					return;

				treeView1.GetPathAtPos((int) ev.X, (int) ev.Y, out TreePath _path);

				treeView1.NodeSelection.SelectPath(_path);

				if (treeView1.NodeSelection.SelectedNode == null) return;
				
				UINode node = (UINode)treeView1.NodeSelection.SelectedNode;
				ShowContextMenu(node, ev);
			}
		}

		private void ShowContextMenu(UINode node, EventButton e)
		{
			Menu menu = new();
			switch (node?.NodeObject?.GetType().ToString())
			{

				case "LevelScriptEditor.Levels.GameLevel":
				{
					//var contextMenuStrip = new ContextMenuStrip();
					break;
				}
				case "LevelScriptEditor.Levels.LevelNPC":
				{
					
					MenuItem menu_item = new("Add file");
					menu.AttachToWidget(treeView1, null);
					LevelNPCMenu(menu, node);
					//menu.Add(menu_item);
					menu.ShowAll();
					//menu.Popup (null, null, null, e.Button, e.Time);
					menu.PopupAtPointer(e);
					//menu.Realize();
					break;
				}
				default:
					Console.WriteLine(node?.NodeObject?.GetType().ToString());
					break;
			}
			
		}

		private void LevelNPCMenu(Menu menu, UINode node)
		{

			///////////
			{
				bool marked = ((LevelNPC)node.NodeObject).Headers.ContainsKey("MARKED");

				MenuItem markLabel = new();
				markLabel.Label = (marked ? "Unmark Complete" : "Mark Complete");
				markLabel.Activated += (s, e) =>
				{
					((LevelNPC)node.NodeObject).ToggleHeader("MARKED");
					RedrawLevelNode((UINode)node.Parent);
				};
				menu.Add(markLabel);
			}

			{
				MenuItem replaceLabel = new ();
				replaceLabel.Label = "Replace similar scripts";
				replaceLabel.Activated += (s, e) =>
				{
					/*
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
					}*/
				};
				menu.Add(replaceLabel);
			}
		}

		#region Update NPC Scripts
		private void SetActiveNode(UINode node)
		{
			// Save current node changes
			if (activeNode != null)
				UpdateActiveNode();
			/*
			 TODO:
			// Clear fields
			npcDescTextBox.Clear();
			npcImageTextBox.Clear();
			npcScriptTextBox.Clear();
			*/
			// Set new node
			activeNode = node;
			if (node != null)
			{
				/*
				 TODO:
				npcDescTextBox.Text = node.NPC.Headers.GetValueOrDefault("DESC", string.Empty);
				npcImageTextBox.Text = node.NPC.Image;
				npcScriptTextBox.Text = node.NPC.Code.Replace("\n", "\r\n");
				*/
			}
		}

		private void UpdateActiveNode()
		{
			if (activeNode != null)
			{
				/*
				 TODO:
				state.UpdateNPC(activeNode,
					npcScriptTextBox.Text.Replace("\r\n", "\n"),
					npcImageTextBox.Text.Trim(),
					npcDescTextBox.Text.Trim(),
					null);
				*/
			}
		}

		private void SetStatusDescription(string text)
		{
			//TODO: toolStripStatusLabel1.Text = text;
		}

		private void NpcDescTextBox_TextChanged(object sender, EventArgs e)
		{
			/*
			var s = (TextBox)sender;
			if (s.Modified)
			{
				UpdateActiveNode();
				if (activeNode != null)
					activeNode.UpdateDescription();
			}
			*/
		}

		private void NpcScriptTextBox_TextChanged(object sender, EventArgs e)
		{
			/*
			var s = (TextBox)sender;
			if (s.Modified)
				UpdateActiveNode();
				*/
		}

		private void NpcImageTextBox_TextChanged(object sender, EventArgs e)
		{
			/*
			var s = (TextBox)sender;
			if (s.Modified)
				UpdateActiveNode();
				*/
		}
		#endregion

		#region Toolbar Options

		private static IEnumerable<string> GetFilesRecursive(string sDir, string pattern)
		{
			try
			{
				List<string> files = Directory.GetFiles(sDir, pattern).ToList();

				foreach (string d in Directory.GetDirectories(sDir))
				{
					files.AddRange(GetFilesRecursive(d, pattern));;
				}

				return files;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				
			}
			return null;
		}
		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//using (var fbd = new FolderBrowserDialog())
			{
				//DialogResult result = fbd.ShowDialog();

				//if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					// TODO(joey): are you sure you want to discard changes?

					// reset state
					SetActiveNode(null);
					state.NodeList.Clear();
					state.LevelChangeList.Clear();
					state.NpcChangeList.Clear();
					treeView1.NodeStore.Clear();

					//state.BaseDir = fbd.SelectedPath;
					string[] files = GetFilesRecursive(state.BaseDir, "*.nw").ToArray();

					if (files.Length > 0)
					{
						// create nodes
						foreach (string file in files)
							state.NodeList.Add(new UINode(state.BaseDir, file));

						// read all levels
						//foreach (UINode node in state.NodeList)
						//	node.Load();

						// sort the nodes (may move into RedrawNodes)
						state.NodeList.Sort(new LevelNodeSorter());

						RedrawNodes();
						SetStatusDescription(string.Format("Loaded folder {0} with {1} levels", state.BaseDir, files.Length));
					}
					else SetStatusDescription(string.Format("No levels found in {0}", state.BaseDir));
				}
			}
		}
/*
		 TODO:
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
			state.ShowEmptyLevels = optionsShowEmptyLevelsMenuItem.Checked;
			RedrawNodes();
		}

		private void OptionsShowCompletedMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			state.ShowCompletedNpcs = optionsShowCompleteMenuItem.Checked;
			RedrawNodes();
		}

		private void OptionsShowEmptyNpcsMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			state.ShowEmptyNpcs = optionsShowEmptyNpcsMenuItem.Checked;
			RedrawNodes();
		}

		private void OptionReplaceMatchImagesMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			state.matchImageNames = optionReplaceMatchImagesMenuItem.Checked;
		}
		*/
		#endregion

		#region Script filtering
		/*
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
		*/
		#endregion

		NodeStore store;
		NodeStore Store => store ??= new NodeStore(typeof(UINode));
		private void RedrawNodes()
		{
			IEnumerable<UINode> nodes = state.NodeList.AsEnumerable();

			if (!state.ShowEmptyLevels)
				nodes = nodes.Where(n => n.ChildCount > 0);

			//m_searchText = searchBox.Text.Replace("\r\n", "\n");

			//treeView1.Nodes.Clear();
			//treeView1.BeginUpdate();

			foreach (UINode n in nodes)
			{
				RedrawLevelNode(n);
				treeView1.NodeStore.AddNode(n);
			}

			//treeView1.EndUpdate();

			// Try to preserve the current position in the treeview
			if (activeNode != null && activeNode.Parent != null)
			{
				/*
				if (activeNode.Parent.LastNode != null)
					activeNode.Parent.LastNode.EnsureVisible();
				else
					activeNode.Parent.EnsureVisible();
				activeNode.EnsureVisible();
				*/
			}
		}

		private void RedrawLevelNode(UINode node)
		{
			/*
			var childNodes = node.ChildrenNodes.AsEnumerable();

			if (!state.ShowCompletedNpcs)
				childNodes = childNodes.Where(n => !n.NPC.Headers.ContainsKey("MARKED"));

			if (!state.ShowEmptyNpcs)
				childNodes = childNodes.Where(n => n.NPC.Code.Trim().Length > 0);

			if (m_searchText.Length > 0)
				childNodes = childNodes.Where(n => n.NPC.Code.Contains(m_searchText));

			node.Nodes.Clear();
			node.Nodes.AddRange(childNodes.ToArray());
			*/
		}

		private void MainWindow_FormClosing(object sender, DeleteEventArgs e)
		{
			int modFileCount = state.LevelChangeList.Count;
			bool cancel = false;
			if (modFileCount > 0)
			{
				//TODO: var window = MessageBox.Show("You still have " + modFileCount.ToString() + " levels with unsaved changes! Click No, and save your changes!", "Close the application without saving?", MessageBoxButtons.YesNo);
				cancel = false; //TODO: (window == DialogResult.No);
			}
			
			if (!cancel)
			{
				Quit();
			}
		}

		private void TreeView1OnPopupMenu(object o, PopupMenuArgs args)
		{
			
			throw new NotImplementedException();
		}
	}
}
