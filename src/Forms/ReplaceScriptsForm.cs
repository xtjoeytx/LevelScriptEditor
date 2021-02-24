using LevelScriptEditor.State;
using LevelScriptEditor.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LevelScriptEditor.Forms
{
	public partial class ReplaceScriptsForm : Form
	{
		private readonly GlobalState state;

		private readonly List<LevelNPCNode> identicalScripts = new List<LevelNPCNode>();

		private readonly string originalCode;

		public ReplaceScriptsForm(GlobalState state, LevelNPCNode npcNode)
		{
			this.state = state;

			InitializeComponent();

			var npc = npcNode.NPC;
			originalCode = npc.Code;

			origDescTextBox.Text = newDescTextBox.Text = npc.Headers.GetValueOrDefault("DESC", string.Empty);
			origImageTextBox.Text = newImageTextBox.Text = npc.Image;
			origScriptTextBox.Text = newScriptTextBox.Text = originalCode.Replace("\n", "\r\n");

			GetIdenticalScripts();
		}

		private void GetIdenticalScripts()
		{
			identicalScripts.Clear();

			foreach (var levelNode in state.nodeList)
			{
				var childNodes = levelNode.ChildrenNodes.AsEnumerable()
											.Where(n => n.NPC.Code == originalCode)
											.Where(n => n.NPC.Image == origImageTextBox.Text);

				foreach (var node in childNodes)
					identicalScripts.Add(node);
			}

			labelIdenticalScripts.Text = identicalScripts.Count.ToString();
		}

		private void ReplaceScriptsButtonClick(object sender, EventArgs e)
		{
			// No scripts to replace, so nothing to do here
			if (identicalScripts.Count < 1)
				return;

			DialogResult result = MessageBox.Show(string.Format("Are you sure you want to replace {0} scripts?", identicalScripts.Count), "Find-Replace Scripts", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{
				var newCode = newScriptTextBox.Text.Replace("\r\n", "\n");
				
				if (identicalScripts.Count > 0)
				{
					identicalScripts[0].TreeView.BeginUpdate();

					foreach (var npcNode in identicalScripts)
					{
						// Mark script as done
						if (markScriptsCheckBox.Checked)
							npcNode.NPC.Headers["MARKED"] = "true";
						else
							npcNode.NPC.Headers.Remove("MARKED");

						// Update NPC
						state.UpdateNPC(npcNode, newCode, newImageTextBox.Text, newDescTextBox.Text);
					}

					identicalScripts[0].TreeView.EndUpdate();
				}

				this.DialogResult = DialogResult.OK;
			}
		}
	}
}
