using System;

namespace SRS.Settings
{
	public interface ISetting
	{
		public void Save();
		public void Load();
	}
}