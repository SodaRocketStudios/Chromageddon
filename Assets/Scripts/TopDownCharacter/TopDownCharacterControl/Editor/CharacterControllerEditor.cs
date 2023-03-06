using UnityEngine;
using UnityEditor;

namespace SRS.TopDownCharacterControl
{
	[CustomEditor(typeof(TopDownCharacterController))]
	public class CharacterControllerEditor : Editor
	{
		private void OnSceneGUI()
		{
			TopDownCharacterController controller = target as TopDownCharacterController;

			Handles.color = Color.green;
			Handles.DrawWireDisc((Vector2)controller.transform.position + controller.ColliderOffset, Vector3.forward, controller.ColliderRadius);
		}
	}
}