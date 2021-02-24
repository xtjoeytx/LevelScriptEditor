using System;
using System.Collections.Generic;

namespace LevelScriptEditor.UI
{
	public class LevelNodeSorter : IComparer<UINode>
	{
		public int Compare(UINode tx, UINode ty)
		{
			int check = (tx.ChildCount > 0 ? 0 : 1) - (ty.ChildCount > 0 ? 0 : 1);
			return check != 0 ? check : string.CompareOrdinal(tx.Text, ty.Text);
		}
	}
}
