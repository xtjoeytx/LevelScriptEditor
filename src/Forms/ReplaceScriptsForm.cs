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

		private readonly bool matchImages;

		public ReplaceScriptsForm(GlobalState state, LevelNPCNode npcNode)
		{
			this.state = state;
			this.matchImages = state.matchImageNames;

			InitializeComponent();

			var npc = npcNode.NPC;
			originalCode = npc.Code;

			markScriptsCheckBox.Checked = (npc.Headers.GetValueOrDefault("MARKED", string.Empty) == "true");
			origDescTextBox.Text = newDescTextBox.Text = npc.Headers.GetValueOrDefault("DESC", string.Empty);
			origImageTextBox.Text = newImageTextBox.Text = npc.Image;
			origScriptTextBox.Text = newScriptTextBox.Text = originalCode.Replace("\n", "\r\n");

			GetIdenticalScripts();
		}

		private void GetIdenticalScripts()
		{
			identicalScripts.Clear();

			bool variableImage = false;

			foreach (var levelNode in state.NodeList)
			{
				var childNodes = levelNode.ChildrenNodes.AsEnumerable()
											.Where(n => n.NPC.Code == originalCode);

				if (matchImages)
					childNodes = childNodes.Where(n => n.NPC.Image == origImageTextBox.Text);

				foreach (var node in childNodes)
				{
					identicalScripts.Add(node);

					if (!variableImage && node.NPC.Image != origImageTextBox.Text)
						variableImage = true;
				}
			}

			if (variableImage)
				newImageTextBox.Text = "[variable]";

			labelIdenticalScripts.Text = identicalScripts.Count.ToString();
		}

		private void ReplaceScriptsButtonClick(object sender, EventArgs e)
		{
			if (identicalScripts.Count < 1)
				return;

			DialogResult result = MessageBox.Show(string.Format("Are you sure you want to replace {0} scripts?", identicalScripts.Count), "Find-Replace Scripts", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{
				string newCode = newScriptTextBox.Text.Replace("\r\n", "\n");

				// dont update images if its [variable]
				string newImage = null;
				if (newImageTextBox.Text != "[variable]")
					newImage = newImageTextBox.Text;

				// update all identical scripts
				foreach (var npcNode in identicalScripts)
				{
					state.UpdateNPC(
						npcNode,
						newCode,
						newImage,
						newDescTextBox.Text,
						markScriptsCheckBox.Checked);
				}

				this.DialogResult = DialogResult.OK;
			}
		}
	}
}
