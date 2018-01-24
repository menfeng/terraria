using System;

namespace Terraria
{
	internal interface IFileProvider
	{
		byte[] GetData(string name);

		string[] GetFiles();
	}
}
