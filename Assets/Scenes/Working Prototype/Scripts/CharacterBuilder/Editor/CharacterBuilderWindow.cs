using UnityEngine;
using UnityEditor;

namespace SRS.CharacterBuilder
{	
	public class CharacterBuilderWindow : EditorWindow
	{
		private string characterName;

		private string saveLocation = "";

		private string characterStatFile = "";

		private string attackStatFile = "";

		[MenuItem("Character Builder/Create New Character")]
		private static void ShowWindow()
		{
			var window = GetWindow<CharacterBuilderWindow>();
			window.titleContent = new GUIContent("Character Builder");
			window.Show();
			window.maxSize = new Vector2(400, 250);
			window.minSize = window.maxSize;
		}
	
		private void OnGUI()
		{
			GUILayout.Label("Character Asset Data");
			characterName = EditorGUILayout.TextField("Name", characterName);
			saveLocation = EditorGUILayout.TextField("Save Location", saveLocation);
			if(GUILayout.Button("Browse"))
			{
				saveLocation = EditorUtility.OpenFolderPanel("Choose save location", Application.dataPath, "");
			}

			GUILayout.Space(20);
			GUILayout.Label("Character Stats");

			characterStatFile = EditorGUILayout.TextField("File Location", characterStatFile);

			EditorGUILayout.BeginHorizontal();

			if(GUILayout.Button("Open stat file"))
			{
				characterStatFile = EditorUtility.OpenFilePanel("Open stat file", Application.dataPath, "csv");
			}
			if(GUILayout.Button("Create New Character Stat File"))
			{
				PopupWindow.Show(new Rect(), new NewFilePopup());
			}

			EditorGUILayout.EndHorizontal();

			GUILayout.Space(20);			

			if(GUILayout.Button("Generate Character", new GUILayoutOption[] {GUILayout.Width(400), GUILayout.Height(50)}))
			{
				// Check for missing information
				Debug.Log($"New character created at Assets/{saveLocation}/{characterName}.");
				// Generate the character
			}
		}
	}
}