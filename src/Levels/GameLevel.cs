using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LevelScriptEditor.Levels
{
	public class GameLevel
	{
		private static readonly string BASE64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
		private readonly string filePath;
		private bool loaded = false;
		
		public string Name => Path.GetFileName(filePath);

		public List<int[]> BoardData = new List<int[]>();
		public List<LevelChest> ChestList = new List<LevelChest>();
		public List<LevelLink> LinkList = new List<LevelLink>();
		public List<LevelNPC> NpcList = new List<LevelNPC>();
		public List<LevelSign> SignList = new List<LevelSign>();

		private GameLevel(string filePath)
		{
			this.filePath = filePath;
		}

		public static GameLevel Load(string filePath)
		{
			var level = new GameLevel(filePath);

			if (level.Reload())
				return level;

			return null;
		}

		private void clear()
		{
			loaded = false;

			BoardData.Clear();
			ChestList.Clear();
			LinkList.Clear();
			NpcList.Clear();
		}

		public bool Reload()
		{
			clear();

			if (Path.GetExtension(filePath) != ".nw")
				return false;

			if (!File.Exists(filePath))
				return false;

			string[] lines = File.ReadAllLines(filePath);
			if (lines[0] != "GLEVNW01")
				return false;

			for (var i = 1; i < lines.Length; i++)
			{
				string[] words = lines[i].Split(" ");
				if (words[0] == "BOARD")
				{
					int sx = int.Parse(words[1]);
					int sy = int.Parse(words[2]);
					int width = int.Parse(words[3]);
					int layer = int.Parse(words[4]);
					string tileData = words[5];

					if (sx < 0 || sx > 64 || sy < 0 || sy > 64 || width <= 0 || sx + width > 64)
						continue;

					while (BoardData.Count <= layer)
						BoardData.Add(new int[64 * 64]);

					if (tileData.Length >= width * 2)
					{
						for (var j = sx; j < sx + width; j++)
						{
							int pos = (j - sx) * 2;
							char left = tileData[pos];
							char top = tileData[pos + 1];
							BoardData[layer][j + sy*64] = (BASE64.IndexOf(left) << 6) + BASE64.IndexOf(top);
						}
					}
				}
				else if (words[0] == "CHEST")
				{
					int chestx = int.Parse(words[1]);
					int chesty = int.Parse(words[2]);
					int signidx = int.Parse(words[4]);
					string chestitem = words[3];
					ChestList.Add(new LevelChest(chestitem, chestx, chesty, signidx));
				}
				else if (words[0] == "LINK")
				{
					if (words.Length < 7)
					{
						System.Diagnostics.Debug.WriteLine(string.Format("Invalid link: {0}", lines[i]));
						continue;
					}

					string levelname = words[1];

					int offset;
					for (offset = 1; offset < words.Length - 7; offset++)
						levelname += " " + words[offset + 1];

					int linkx = int.Parse(words[offset + 1]);
					int linky = int.Parse(words[offset + 2]);
					int linkw = int.Parse(words[offset + 3]);
					int linkh = int.Parse(words[offset + 4]);
					string linkwarpx = words[offset + 5];
					string linkwarpy = words[offset + 6];

					var linkItem = new LevelLink(levelname, linkx, linky, linkw, linkh, linkwarpx, linkwarpy);
					LinkList.Add(linkItem);
				}
				else if (words[0] == "SIGN")
				{
					int signx = int.Parse(words[1]);
					int signy = int.Parse(words[2]);
					string text = string.Empty;

					while (++i < lines.Length)
					{
						if (lines[i] == "SIGNEND")
							break;
						text += lines[i] + "\n";
					}

					var sign = new LevelSign(signx, signy, text);
					SignList.Add(sign);
				}
				else if (words[0] == "NPC")
				{
					if (words.Length < 4)
					{
						System.Diagnostics.Debug.WriteLine(string.Format("Invalid NPC: {0}", lines[i]));
						continue;
					}

					string npcimg = words[1];

					int offset;
					for (offset = 1; offset < words.Length - 3; offset++)
						npcimg += " " + words[offset + 1];

					double npcx = double.Parse(words[offset + 1]);
					double npcy = double.Parse(words[offset + 2]);

					string code = string.Empty;
					while (++i < lines.Length)
					{
						if (lines[i] == "NPCEND")
							break;
						code += lines[i] + "\n";
					}

					var npc = new LevelNPC(npcx, npcy, npcimg, code);
					NpcList.Add(npc);
				}
			}

			loaded = true;
			return true;
		}

		public void Save()
		{
			if (!loaded)
				return;

			File.WriteAllText(filePath, getOutput());
		}

		public string getOutput()
		{
			var sb = new StringBuilder();

			// header
			sb.Append("GLEVNW01\n");

			// write board
			for (var layer = 0; layer < BoardData.Count; layer++)
			{
				for (var y = 0; y < 64; y++)
				{
					string boardLine = string.Format("BOARD {0} {1} {2} {3} ", 0, y, 64, layer);
					for (var x = 0; x < 64; x++)
					{
						var tile = BoardData[layer][x + y*64];
						var left = (tile >> 6) & 0x3F;
						var top = tile & 0x3F;
						string codeStr = BASE64[left].ToString() + BASE64[top].ToString();
						boardLine += codeStr;
					}
					sb.Append(boardLine).Append('\n');
				}
			}

			// write links
			foreach (var link in LinkList)
				sb.Append(link.GetOutput()).Append('\n');

			// write signs
			foreach (var sign in SignList)
				sb.Append(sign.GetOutput()).Append('\n');

			// write chests
			foreach (var chest in ChestList)
				sb.Append(chest.GetOutput()).Append('\n');

			// write npcs
			foreach (var npc in NpcList)
				sb.Append(npc.GetOutput()).Append('\n');

			return sb.ToString();
		}
	}
}
