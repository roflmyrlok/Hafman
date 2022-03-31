using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Havman
{
	public class FileReader
	{
		public List<string> ReadLines(string path)
			{
				var list = new List<string>();
				var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
				{
					string line;
					while ((line = streamReader.ReadLine()) != null) list.Add(line);
				}
				return list;
				
			}
	}
}