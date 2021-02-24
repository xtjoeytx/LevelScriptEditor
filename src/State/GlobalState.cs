using LevelScriptEditor.UI;
using System.Collections.Generic;

namespace LevelScriptEditor.State
{
	public class GlobalState
	{
		public string baseDir = "";

		public bool showCompletedNpcs = true;
		public bool showEmptyLevels = false;
		public bool showEmptyNpcs = false;

		public List<LevelNode> nodeList = new List<LevelNode>();
		
		public HashSet<LevelNode> levelChangeList = new HashSet<LevelNode>();
		public HashSet<LevelNPCNode> npcChangeList = new HashSet<LevelNPCNode>();

		public void UpdateNPC(LevelNPCNode npcNode, string code, string image, string desc)
		{
			var npc = npcNode.NPC;

			// Nothing has changed here
			var npcDesc = npc.Headers.GetValueOrDefault("DESC", string.Empty);
			if (npc.Code == code && npc.Image == image && npcDesc == desc)
				return;
			
			// Copy changes over
			var levelNode = (LevelNode)npcNode.Parent;
			npc.Code = code;
			npc.Image = image;
			npc.Headers["DESC"] = desc;

			// If we have a new description, update the tree node to reflect it
			// NOTE: if you're doing mass-changes to many npcs, you should be using begin/endupdate on the treeview
			// otherwise it will be rendering after every change.
			if (npcDesc != desc)
				npcNode.UpdateDescription();

			npcChangeList.Add(npcNode);
			levelChangeList.Add(levelNode);
		}

		public void SaveLevels()
		{
			foreach (var levelChange in levelChangeList)
				levelChange.Save();
			levelChangeList.Clear();
			npcChangeList.Clear();
		}
	}
}
