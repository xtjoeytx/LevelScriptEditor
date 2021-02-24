using LevelScriptEditor.Levels;
using System.Collections.Generic;
using System.IO;
using Gtk;

namespace LevelScriptEditor.UI
{
	public partial class LevelNode : TreeNode
	{
		private string filePath;

		public bool Loaded => GameLevel != null;

		public GameLevel GameLevel { get; private set; } = null;
		[TreeNodeValue (Column=0)]
		public string Text { get; set; }
		
		[TreeNodeValue (Column=1)]
		public string FilePath => filePath;

		public LevelNode(string baseDir, string name)
			/*: base(name)*/
		{
			Text = name;
			filePath = Path.Combine(baseDir, name);
		}


		//public List<LevelNPCNode> ChildrenNodes = new List<LevelNPCNode>();

		public void Load()
		{
			//Nodes.Clear();
			//ChildrenNodes.Clear();

			GameLevel = GameLevel.Load(filePath);
			if (GameLevel == null) return;
			
			for (int i = 0; i < GameLevel.NpcList.Count; i++)
			{
				LevelNPC npc = GameLevel.NpcList[i];
				
				/*ChildrenNodes.*/AddChild(new LevelNPCNode(npc, i + 1));
			}
		}

		public void Save()
		{
			if (Loaded)
				GameLevel.Save();
		}
	}
}
