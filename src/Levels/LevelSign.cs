namespace LevelScriptEditor.Levels
{
	public class LevelSign
	{
		public int X;
		public int Y;
		public string Message;

		public LevelSign(int signx, int signy, string text)
		{
			this.X = signx;
			this.Y = signy;
			this.Message = text;
		}

		public string GetOutput()
		{
			if (Message.EndsWith('\n'))
				Message = Message.Substring(0, Message.Length - 1);

			return string.Format("SIGN {0} {1}\n{2}\nSIGNEND", X, Y, Message);
		}
	}
}