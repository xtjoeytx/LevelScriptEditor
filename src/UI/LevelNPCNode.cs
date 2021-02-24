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
			Text = (npc.Headers.ContainsKey("DESC") && npc.Headers["DESC"] != string.Empty) ? npc.Headers["DESC"] : "NPC " + npcId;
		}
	}
}
