using UnityEngine;
using UnityEditor;

namespace SRS.TopDownCharacterControl
{
	[CustomEditor(typeof(TopDownCharacterController))]
	public class CharacterControllerInspector : Editor
	{
		private void OnSceneGUI()
		{
			TopDownCharacterController script = (TopDownCharacterController)target;

			Bounds bounds = script.gameObject.GetComponent<CircleCollider2D>().bounds;
			Vector2 position = script.transform.position;

			Vector2 top = new Vector2(0, bounds.extents.y) + (Vector2)position;
			Vector2 bottom = new Vector2(0, -bounds.extents.y) + (Vector2)position;
			Vector2 right = new Vector2(bounds.extents.x, 0) + (Vector2)position;
			Vector2 left = new Vector2(-bounds.extents.x, 0) + (Vector2)position;
			Vector2 vertBoxSize = new Vector2(script.BoxWidth, bounds.extents.y);
			Vector2 horizBoxSize = new Vector2(bounds.extents.x, script.BoxWidth);

			Handles.color = Color.green;

			Handles.DrawWireCube(top, horizBoxSize);
			Handles.DrawWireCube(bottom, horizBoxSize);
			Handles.DrawWireCube(left, vertBoxSize);
			Handles.DrawWireCube(right, vertBoxSize);
		}
	}
}