using LevelScriptEditor.UI;
using System.Collections.Generic;
using LevelScriptEditor.Levels;

namespace LevelScriptEditor.State
{
	public class GlobalState
	{
		public string BaseDir = "";

		public bool ShowCompletedNpcs = true;
		public bool ShowEmptyLevels = true;
		public bool ShowEmptyNpcs = false;

		public readonly List<UINode> NodeList = new();
		
		public readonly HashSet<UINode> LevelChangeList = new();
		public readonly HashSet<UINode> NpcChangeList = new();

		public void UpdateNPC(UINode npcNode, string code, string image, string desc)
		{
			LevelNPC npc = (LevelNPC)npcNode.NodeObject;

			// Nothing has changed here
			string npcDesc = npc.Headers.GetValueOrDefault("DESC", string.Empty);
			if (npc.Code == code && npc.Image == image && npcDesc == desc)
				return;
			
			// Copy changes over
			var levelNode = (UINode)npcNode.Parent;
			npc.Code = code;
			npc.Image = image;
			npc.Headers["DESC"] = desc;

			// If we have a new description, update the tree node to reflect it
			// NOTE: if you're doing mass-changes to many npcs, you should be using begin/endupdate on the treeview
			// otherwise it will be rendering after every change.
			if (npcDesc != desc)
				npcNode.UpdateDescription();

			NpcChangeList.Add(npcNode);
			LevelChangeList.Add(levelNode);
		}

		public void SaveLevels()
		{
			foreach (UINode levelChange in LevelChangeList)
				levelChange.Save();
			LevelChangeList.Clear();
			NpcChangeList.Clear();
		}
	}
}
