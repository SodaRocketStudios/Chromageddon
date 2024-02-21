using UnityEngine;

namespace SRS.Input
{
	public static class CursorManager
	{
		public static void SwapToController()
		{
			Cursor.visible = false;
		}

		public static void SwapToMouse()
		{
			Cursor.visible = true;
		}
	}
}