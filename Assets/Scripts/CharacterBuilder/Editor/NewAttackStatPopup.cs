using UnityEngine;
using UnityEditor;
using System.IO;

namespace SRS.CharacterBuilder
{
	public class NewAttackStatPopup : PopupWindowContent
	{
        private string fileName = "New Attack Stats";

		private string saveLocation;

        public override void OnGUI(Rect rect)
        {
            GUILayout.Label("New Attack Stats");
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
				string templatePath = $"{Application.dataPath}/Editor Default Resources/AttackStatTemplate.csv";

				if(string.IsNullOrEmpty(fileName)) fileName = "New Attack Stats";

				try
				{
					File.Copy(templatePath, $"{Application.dataPath}/{saveLocation}/{fileName}.csv");
					Debug.Log($"New attack stats created at Assets/{saveLocation}/{fileName}.csv");
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