using System.Collections.Generic;
using System.Text;

namespace LevelScriptEditor.Levels
{
	public class LevelNPC
	{
		const string META_PREFIX = "//#[";
		const char META_SEP = ':';
		const char META_SUFFIX = ']';

		private readonly GameLevel level;

		public Dictionary<string, string> Headers = new Dictionary<string, string>();
		public GameLevel Level { get => level; }
		public string Image;
		public string Code;
		public double X;
		public double Y;
		private string _npcMadeBy = string.Empty;

		public LevelNPC(GameLevel level, double x, double y, string image, string script)
		{
			this.level = level;
			this.Image = image;
			this.X = x;
			this.Y = y;
			SetCode(script);
		}

		public string GetOutput()
		{
			var sb = new StringBuilder();
			sb.AppendFormat("NPC {0} {1} {2}\n", Image, X, Y);

			foreach (var header in Headers)
			{
				if (!string.IsNullOrWhiteSpace(header.Value))
				{
					sb.Append(META_PREFIX).Append(header.Key);

					if (header.Value != "true")
						sb.Append(META_SEP).Append(header.Value);

					sb.Append(META_SUFFIX).Append('\n');
				}
			}

			if (_npcMadeBy != string.Empty)
				sb.Append(_npcMadeBy).Append('\n');

			sb.Append(Code.Replace("\r\n", "\n"));
			if (!Code.EndsWith("\n"))
				sb.Append('\n');

			sb.Append("NPCEND");
			return sb.ToString();
		}

		private void SetCode(string code)
		{
			string[] lines = code.Split('\n');

			code = string.Empty;

			bool finishedHeader = false;
			foreach (var line in lines)
			{
				if (!finishedHeader)
				{
					if (line.StartsWith(META_PREFIX) && line.EndsWith(META_SUFFIX))
					{
						string key, val;

						var sep = line.IndexOf(META_SEP);
						if (sep > 0)
						{
							key = line[META_PREFIX.Length..sep];
							val = line[(sep + 1)..].TrimEnd(META_SUFFIX);
						}
						else
						{
							key = line[META_PREFIX.Length..].TrimEnd(META_SUFFIX);
							val = "true";
						}

						Headers[key] = val;
					}
					else
					{
						finishedHeader = true;

						if (line.StartsWith("// NPC made by "))
							_npcMadeBy = line;
						else
							code = line;
					}
				}
				else
				{
					if (code != string.Empty)
						code += '\n';
					code += line;
				}
			}

			this.Code = code.Trim();
		}

		public void ToggleHeader(string key)
		{
			if (Headers.ContainsKey(key))
			{
				Headers.Remove(key);
			}
			else
			{
				Headers.Add(key, "true");
			}
		}
	}
}
