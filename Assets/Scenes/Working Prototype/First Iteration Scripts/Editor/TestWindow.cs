using UnityEngine;
using UnityEditor;

namespace SRS
{
	public class TestWindow : EditorWindow
	{
		private float num;

		[MenuItem("Window/Test Window")]
		private static void ShowWindow()
		{
			var window = GetWindow<TestWindow>();
			window.titleContent = new GUIContent("Test");
			window.Show();
		}
		
		private void OnGUI()
		{
			num = EditorGUILayout.Slider(num, 0, 100);
		}
	}

	
}