using System.Collections.Generic;

namespace LevelScriptEditor.UI
{
	public class LevelNodeSorter : IComparer<LevelNode>
	{
		public LevelNodeSorter() { }

		public int Compare(LevelNode tx, LevelNode ty)
		{
			var check = (tx.Nodes.Count > 0 ? 0 : 1) - (ty.Nodes.Count > 0 ? 0 : 1);
			if (check != 0)
				return check;

			return string.Compare(tx.Text, ty.Text);
		}
	}
}
