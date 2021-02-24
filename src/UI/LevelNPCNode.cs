using LevelScriptEditor.Levels;
using Gtk;

namespace LevelScriptEditor.UI
{
	public class LevelNPCNode : TreeNode
	{
		private readonly int _npcId = 0;
		private string _text = null;

		public LevelNPC NPC { get; } = null;
		
		[TreeNodeValue (Column=0)]
		public string Text => _text;

		[TreeNodeValue (Column=1)]
		public string test = "";

		public LevelNPCNode(LevelNPC levelNPC, int npcId) : base()
		{
			NPC = levelNPC;
			_npcId = npcId;
			UpdateDescription();
		}

		public void UpdateDescription()
		{
			_text = NPC.Headers.ContainsKey("DESC") && NPC.Headers["DESC"] != string.Empty ? NPC.Headers["DESC"] : "NPC " + _npcId;
		}
	}
}
