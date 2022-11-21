using UnityEngine;

namespace SRS.CustomCursor
{
	public class CursorTexture : MonoBehaviour
	{
		public Texture2D cursorTexture;
		public CursorMode cursorMode = CursorMode.Auto;
		public Vector2 hotSpot = Vector2.zero;
		void Start()
		{
			hotSpot = new Vector2(cursorTexture.width/2, cursorTexture.height/2);
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		}
	}
}