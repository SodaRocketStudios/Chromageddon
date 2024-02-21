using UnityEngine;

namespace SRS.Input
{
	public static class CursorManager
	{
		public static void SwapToController()
		{
			Debug.Log("Controller");
			Cursor.visible = false;
		}

		public static void SwapToMouse()
		{
			Debug.Log("KBM");
			Cursor.visible = true;
		}

		public static void DrawAimGuide(Vector2 origin, Vector2 direction)
		{
			Debug.DrawRay(origin, direction*5);
		}
	}
}