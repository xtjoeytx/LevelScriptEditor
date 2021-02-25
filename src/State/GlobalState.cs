using LevelScriptEditor.Levels;
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
		public bool matchImageNames = true;

		public List<LevelNode> nodeList = new List<LevelNode>();
		
		public HashSet<GameLevel> levelChangeList = new HashSet<GameLevel>();
		public HashSet<LevelNPCNode> npcChangeList = new HashSet<LevelNPCNode>();

		public bool UpdateNPC(LevelNPCNode npcNode, string code, string image, string desc, bool? markComplete)
		{
			var npc = npcNode.NPC;
			bool changed = false;

			if (code != null && npc.Code != code)
			{
				npc.Code = code;
				changed = true;
			}

			if (image != null && npc.Image != image)
			{
				npc.Image = image;
				changed = true;
			}

			if (desc != null)
			{
				if (npc.Headers.GetValueOrDefault("DESC", string.Empty) != desc)
				{
					npc.Headers["DESC"] = desc;
					changed = true;
				}
			}

			if (markComplete != null)
			{
				bool npcMarkComplete = (npc.Headers.GetValueOrDefault("MARKED", string.Empty) == "true");
				if (markComplete != npcMarkComplete)
				{
					if (markComplete == true)
						npcNode.NPC.Headers["MARKED"] = "true";
					else
						npcNode.NPC.Headers.Remove("MARKED");
					changed = true;
				}
			}

			if (changed)
			{
				npcChangeList.Add(npcNode);
				levelChangeList.Add(npc.Level);
			}

			return changed;
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
