using UnityEngine;
using UnityEditor;
using System.IO;

namespace SRS.CharacterBuilder
{
    public class NewFilePopup : PopupWindowContent
    {
		private string fileName;

        public override void OnGUI(Rect rect)
        {
            GUILayout.Label("New File");
			fileName = EditorGUILayout.TextField("File Name", fileName);

			if(GUILayout.Button("Cancel"))
			{
				editorWindow.Close();
			}
			if(GUILayout.Button("Create"))
			{
				File.Create($"{Application.dataPath}/{fileName}").Close();
				editorWindow.Close();
			}
        }
    }
}