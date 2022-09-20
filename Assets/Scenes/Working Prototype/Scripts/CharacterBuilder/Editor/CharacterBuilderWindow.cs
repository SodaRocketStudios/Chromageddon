using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using SRS.Stats;
using SRS.DataReader;

namespace SRS.CharacterBuilder
{	
	public class CharacterBuilderWindow : EditorWindow
	{
		private string characterName = "New Character Data";

		private string saveLocation;

		private string characterStatFile;

		private string attackStatFile;

		[MenuItem("Character Builder/Create New Character")]
		private static void ShowWindow()
		{
			var window = GetWindow<CharacterBuilderWindow>();
			window.titleContent = new GUIContent("Character Builder");
			window.Show();
			window.maxSize = new Vector2(407, 310);
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
			if(GUILayout.Button("Create new character stats"))
			{
				PopupWindow.Show(new Rect(), new NewCharacterStatPopup());
			}
			EditorGUILayout.EndHorizontal();

			GUILayout.Space(20);
			GUILayout.Label("Attack Stats");

			attackStatFile = EditorGUILayout.TextField("File Location", attackStatFile);

			EditorGUILayout.BeginHorizontal();
			if(GUILayout.Button("Open stat file"))
			{
				attackStatFile = EditorUtility.OpenFilePanel("Open stat file", Application.dataPath, "csv");
			}
			if(GUILayout.Button("Create new attack stats"))
			{
				PopupWindow.Show(new Rect(), new NewAttackStatPopup());
			}
			EditorGUILayout.EndHorizontal();

			GUILayout.Space(20);			

			if(GUILayout.Button("Generate Character", new GUILayoutOption[] {GUILayout.Width(400), GUILayout.Height(50)}))
			{
				// Check for missing information

				if(string.IsNullOrEmpty(characterName)) characterName = "New Character Data";

				CharacterDataObject statObject = ScriptableObject.CreateInstance<CharacterDataObject>();

				List<Dictionary<string, object>> stats = CSVReader.Read(characterStatFile);

				foreach(Dictionary<string, object> stat in stats)
				{
					string statName = stat["Name"].ToString();
					float baseValue = float.Parse(stat["Base Value"].ToString());
					float additive = float.Parse(stat["Additive Modifier"].ToString());
					float multiplicative = float.Parse(stat["Multiplicative Modifier"].ToString());
					float flat = float.Parse(stat["Flat Modifier"].ToString());

					Stat newStat = new Stat(statName, baseValue, additive, multiplicative, flat);

					statObject.CharacterStats[stat["Name"].ToString()] = newStat;
				}
				
				// statObject.AttackStats;

				AssetDatabase.CreateAsset(statObject, $"Assets/{saveLocation}/{characterName}");
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();

				EditorUtility.FocusProjectWindow();
				Selection.activeObject = statObject;

				Debug.Log($"New character data created at {AssetDatabase.GetAssetPath(statObject)}");
			}
		}
	}
}