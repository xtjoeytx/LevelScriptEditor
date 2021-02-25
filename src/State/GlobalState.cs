using LevelScriptEditor.Levels;
using LevelScriptEditor.UI;
using System.Collections.Generic;
using LevelScriptEditor.Levels;

namespace LevelScriptEditor.State
{
	public class GlobalState
	{
		public string BaseDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()?.Location);

		public bool ShowCompletedNpcs = true;
		public bool ShowEmptyLevels = true;
		public bool ShowEmptyNpcs = false;
		public bool MatchImageNames = true;

		public readonly List<UINode> NodeList = new();
		
		public readonly HashSet<GameLevel> LevelChangeList = new();
		public readonly HashSet<UINode> NpcChangeList = new();

		public bool UpdateNPC(UINode npcNode, string code, string image, string desc, bool? markComplete)
		{
			LevelNPC npc = (LevelNPC)npcNode.NodeObject;
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
						((LevelNPC)npcNode.NodeObject).Headers["MARKED"] = "true";
					else
						((LevelNPC)npcNode.NodeObject).Headers.Remove("MARKED");
					changed = true;
				}
			}

			if (changed)
			{
				NpcChangeList.Add(npcNode);
				LevelChangeList.Add(npc.Level);
			}

			return changed;
		}

		public void SaveLevels()
		{
			foreach (GameLevel levelChange in LevelChangeList)
				levelChange.Save();

			LevelChangeList.Clear();
			NpcChangeList.Clear();
		}
	}
}
