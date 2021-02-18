using LevelScriptEditor.Levels;
using System.Windows.Forms;

namespace LevelScriptEditor.UI
{
	public class LevelNPCNode : TreeNode
	{
		private readonly LevelNPC npc = null;
		private readonly int npcId = 0;

		public LevelNPC NPC { get => npc; }

		public LevelNPCNode(LevelNPC levelNPC, int npcId)
			: base()
		{
			this.npc = levelNPC;
			this.npcId = npcId;
			UpdateDescription();
		}

		public void UpdateDescription()
		{
			this.Text = (npc.Description != string.Empty ? npc.Description : "NPC " + npcId);
		}
	}
}
