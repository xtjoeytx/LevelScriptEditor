namespace LevelScriptEditor.Levels
{
	public class LevelChest
	{
		public string ItemName;
		public int X;
		public int Y;
		public int SignIndex;

		public LevelChest(string item, int x, int y, int sign)
		{
			this.ItemName = item;
			this.X = x;
			this.Y = y;
			this.SignIndex = sign;
		}

		public string GetOutput()
		{
			return string.Format("CHEST {0} {1} {2} {3}", X, Y, ItemName, SignIndex);
		}
	}
}
