using UnityEngine;
using UnityEditor;

namespace SRS.CharacterBuilder
{	
	public class CharacterBuilderWindow : EditorWindow
	{
		private string characterName;
		private string characterStatFile = "Assets/";
		private string attackStatFile = "Assets/";

		[MenuItem("Stats/CharacterBuilderWindow")]
		private static void ShowWindow() {
			var window = GetWindow<CharacterBuilderWindow>();
			window.titleContent = new GUIContent("CharacterBuilderWindow");
			window.Show();
		}
	
		private void OnGUI()
		{
			characterName = EditorGUILayout.TextField("Character Name", characterName);
			characterStatFile = EditorGUILayout.TextField("Character Stat File Location", characterStatFile);
		}
	}
}