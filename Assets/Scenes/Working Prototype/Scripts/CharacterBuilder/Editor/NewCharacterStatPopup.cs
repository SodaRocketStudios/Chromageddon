using UnityEngine;
using UnityEditor;
using System.IO;

namespace SRS.CharacterBuilder
{
    public class NewCharacterStatPopup : PopupWindowContent
    {
		private string fileName = "New Character Stats";
		private string saveLocation;

        public override void OnGUI(Rect rect)
        {
            GUILayout.Label("New Character Stats");
			fileName = EditorGUILayout.TextField("File Name", fileName);
			saveLocation = EditorGUILayout.TextField("File Name", saveLocation);
			if(GUILayout.Button("Browse"))
			{
				saveLocation = EditorUtility.OpenFolderPanel("Choose save location", Application.dataPath, "");
			}

			GUILayout.BeginHorizontal();
			if(GUILayout.Button("Cancel"))
			{
				editorWindow.Close();
			}

			if(GUILayout.Button("Create"))
			{
				string templatePath = $"{Application.dataPath}/Editor Default Resources/CharacterStatTemplate.csv";

				if(string.IsNullOrEmpty(fileName)) fileName = "New Character Stats";

				try
				{
					File.Copy(templatePath, $"{Application.dataPath}/{fileName}.csv");
					Debug.Log($"New character stats created at Assets/{saveLocation}/{saveLocation}/{fileName}.csv");
				}
				catch
				{
					Debug.LogWarning("Stat file already exists.");
				}

				editorWindow.Close();
				AssetDatabase.Refresh();
			}
			GUILayout.EndHorizontal();
        }
    }
}