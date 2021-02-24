namespace LevelScriptEditor.Levels
{
	public class LevelLink
	{
		public string Level;
		public int X;
		public int Y;
		public int W;
		public int H;
		public string WarpX;
		public string WarpY;

		public LevelLink(string levelname, int linkx, int linky, int linkw, int linkh, string linkwarpx, string linkwarpy)
		{
			this.Level = levelname;
			this.X = linkx;
			this.Y = linky;
			this.W = linkw;
			this.H = linkh;
			this.WarpX = linkwarpx;
			this.WarpY = linkwarpy;
		}

		public string GetOutput()
		{
			return string.Format("LINK {0} {1} {2} {3} {4} {5} {6}", Level, X, Y, W, H, WarpX, WarpY);
		}
	}
}
