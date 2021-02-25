using LevelScriptEditor.Levels;
using System.Collections.Generic;
using System.IO;
using Gtk;

namespace LevelScriptEditor.UI
{
	public class UINode : TreeNode
	{
		public bool Loaded => NodeObject != null;
		private int _npcId = 0;

		public INodeObject NodeObject { get; private set; } = null;
		
		[TreeNodeValue (Column=0)]
		public string Text { get; set; }

		public UINode(string baseDir, string filePath)
		{
			Text = filePath.Replace($"{baseDir}{Path.DirectorySeparatorChar}","");
			//string filePath = Path.Combine(baseDir, name);
			NodeObject = GameLevel.Load(filePath);
			if (NodeObject == null) return;
			
			for (int i = 0; i < ((GameLevel)NodeObject).NpcList.Count; i++)
			{
				LevelNPC npc = ((GameLevel)NodeObject).NpcList[i];
				
				AddChild(new UINode(npc, i + 1));
			}
		}

		private UINode(LevelNPC levelNPC, int npcId) : base()
		{
			NodeObject = levelNPC;
			_npcId = npcId;
			UpdateDescription();
		}

		public void UpdateDescription()
		{
			string newDesc = (((LevelNPC)NodeObject).Headers.ContainsKey("DESC") && ((LevelNPC)NodeObject).Headers["DESC"] != string.Empty) ? ((LevelNPC)NodeObject).Headers["DESC"] : $"NPC {_npcId}";
			if (newDesc != Text)
				Text = newDesc;
		}

		public void Save()
		{
			if (Loaded)
				((GameLevel)NodeObject).Save();
		}
	}

	public interface INodeObject
	{
	}
}