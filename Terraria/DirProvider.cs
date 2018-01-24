using System;
using System.Collections.Generic;
using System.IO;

namespace Terraria
{
	internal class DirProvider : IFileProvider
	{
		private DirectoryInfo Dir;

		public DirProvider(DirectoryInfo di)
		{
			this.Dir = di;
		}

		public byte[] GetData(string name)
		{
			name += ".png";
			return File.ReadAllBytes(Path.Combine(this.Dir.FullName, name));
		}

		public string[] GetFiles()
		{
			List<string> list = new List<string>();
			FileInfo[] files = this.Dir.GetFiles("*.png");
			for (int i = 0; i < files.Length; i++)
			{
				FileInfo fileInfo = files[i];
				list.Add(Path.GetFileNameWithoutExtension(fileInfo.Name));
			}
			return list.ToArray();
		}
	}
}
