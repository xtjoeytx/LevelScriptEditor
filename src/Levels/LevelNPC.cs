using System.Text;

namespace LevelScriptEditor.Levels
{
	public class LevelNPC
	{
		const string descriptionTag = "//#DESC:";

		public string Image;
		public string Code;
		public string Description = string.Empty;
		public double X;
		public double Y;

		public LevelNPC(double x, double y, string image, string code)
		{
			this.Image = image;
			this.X = x;
			this.Y = y;
			SetCode(code);
		}

		public string getOutput()
		{
			var sb = new StringBuilder();
			sb.AppendFormat("NPC {0} {1} {2}\n", Image, X, Y);
			if (Description != string.Empty)
				sb.Append(descriptionTag).Append(" ").Append(Description).Append("\n");

			sb.Append(Code.Replace("\r\n", "\n"));
			if (!Code.EndsWith("\n"))
				sb.Append("\n");

			sb.Append("NPCEND");
			return sb.ToString();
		}

		private void SetCode(string code)
		{
			if (code.StartsWith(descriptionTag))
			{
				int pos = code.IndexOf(descriptionTag);
				if (pos >= 0)
				{
					int end = code.IndexOf("\n", pos);
					if (end >= 0)
					{
						this.Description = code.Substring(pos + descriptionTag.Length, end - descriptionTag.Length).Trim();
						code = code.Substring(end + 1);
					}
				}
			}

			this.Code = code;
		}
	}
}
