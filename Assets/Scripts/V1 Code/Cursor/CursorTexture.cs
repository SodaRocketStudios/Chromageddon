using UnityEngine;

namespace SRS.CustomCursor
{
	public class CursorTexture : MonoBehaviour
	{
		[SerializeField] private Texture2D cursorTexture;
		[SerializeField] private CursorMode cursorMode = CursorMode.Auto;

		void Start()
		{
			Vector2 hotSpot = new Vector2(cursorTexture.width/2, cursorTexture.height/2);
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
		}
	}
}