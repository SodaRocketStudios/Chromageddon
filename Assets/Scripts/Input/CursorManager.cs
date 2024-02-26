using UnityEngine;

namespace SRS.Input
{
	public static class CursorManager
	{
		public static void HideCursor()
		{
			Cursor.visible = false;
		}

		public static void ShowCursor()
		{
			Cursor.visible = true;
		}
	}
}