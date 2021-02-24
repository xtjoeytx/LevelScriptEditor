using LevelScriptEditor.Levels;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LevelScriptEditor.UI
{
	public partial class LevelNode : TreeNode
	{
		private string filePath = string.Empty;
		private GameLevel level = null;

		public bool Loaded { get => level != null; }

		public GameLevel GameLevel { get => level; }
			
		public LevelNode(string baseDir, string name)
			: base(name)
		{
			this.filePath = Path.Combine(baseDir, name);
		}


		public List<LevelNPCNode> ChildrenNodes = new List<LevelNPCNode>();

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

		public void Save()
		{
			if (Loaded)
				level.Save();
		}
	}
}
