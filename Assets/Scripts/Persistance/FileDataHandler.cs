using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace SRS.DataPersistence
{
    public class FileDataHandler : DataHandler
    {
        public override string Read(string location)
        {
			string path = BuildPath(location);

			StringBuilder data = new();

			if(File.Exists(path))
			{
				try
				{
					using(FileStream stream = new(path, FileMode.Open))
					{
						using(StreamReader reader = new(stream))
						{
							data.Append(reader.ReadToEnd());
						}
					}
				}
				catch(Exception e)
				{
					Debug.LogError($"An error occured while trying to Read save data from file: {path}\n{e}");
				}
			}

            return data.ToString();
        }

        public override void Write(string location, string data)
        {
			string path = BuildPath(location);
			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(path));

				using(FileStream stream = new(path, FileMode.Create))
				{
					using(StreamWriter writer = new(stream))
					{
						writer.Write(data);
					}
				}
			}
			catch(Exception e)
			{
				Debug.LogError($"An error occured while trying to write save data to file: {path}\n{e}");
			}
        }

		private string BuildPath(string fileName)
		{
			return Path.Combine(Application.persistentDataPath, fileName);
		}
    }
}