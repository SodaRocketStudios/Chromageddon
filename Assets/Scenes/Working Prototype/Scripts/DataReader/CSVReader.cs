using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace SRS.DataReader
{
	public class CSVReader
	{
		static string DATA_SPLIT = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
		static char[] TRIM_CHARACTERS  = { '\"' };

		public static List<Dictionary<string, object>> Read(string file)
		{
			var list = new List<Dictionary<string, object>>();

			string[] lines = File.ReadAllLines(file);

			if(lines.Length <= 1) return list;

			var header = Regex.Split(lines[0], DATA_SPLIT);

			for(var i = 1; i < lines.Length; i++)
			{

				var values = Regex.Split(lines[i], DATA_SPLIT);
				if(values.Length == 0 ||values[0] == "") continue;

				var entry = new Dictionary<string, object>();

				for(var j = 0; j < header.Length && j < values.Length; j++ )
				{
					string value = values[j];
					value = value.TrimStart(TRIM_CHARACTERS).TrimEnd(TRIM_CHARACTERS).Replace("\\", "");
					object finalvalue = value;
					int n;
					float f;

					if(int.TryParse(value, out n))
					{
						finalvalue = n;
					}
					else if (float.TryParse(value, out f))
					{
						finalvalue = f;
					}

					entry[header[j]] = finalvalue;
				}

				list.Add (entry);
			}
			return list;
		}
	}
}