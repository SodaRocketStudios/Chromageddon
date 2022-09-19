using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;

namespace SRS.DataReader
{
	public class CSVReader
	{
		static string DATA_SPLIT = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
		static string LINE_SPLIT = @"\r\n|\n\r|\n|\r";
		static char[] TRIM_CHARACTERS  = { '\"' };

		public static List<Dictionary<string, object>> Read(string file)
		{
			var list = new List<Dictionary<string, object>>();
			TextAsset data = Resources.Load (file) as TextAsset;
			// TextAsset data = AssetDatabase.LoadAssetAtPath(file, typeof(TextAsset)) as TextAsset;

			var lines = Regex.Split (data.text, LINE_SPLIT);

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