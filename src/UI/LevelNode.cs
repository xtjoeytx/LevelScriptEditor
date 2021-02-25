using LevelScriptEditor.Levels;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LevelScriptEditor.UI
{
	public class LevelNode : TreeNode
	{
		private string filePath = string.Empty;
		private GameLevel level;

		public GameLevel GameLevel { get => level; }

		public List<LevelNPCNode> ChildrenNodes = new List<LevelNPCNode>();

		public LevelNode(string baseDir, string name)
			: base(name)
		{
			this.filePath = Path.Combine(baseDir, name);
		}

		public void Load()
		{
			Nodes.Clear();
			ChildrenNodes.Clear();

			level = GameLevel.Load(filePath);
			if (level != null)
			{
				for (int i = 0; i < level.NpcList.Count; i++)
				{
					var npc = level.NpcList[i];
					ChildrenNodes.Add(new LevelNPCNode(npc, i + 1));
				}
			}
		}
	}
}
