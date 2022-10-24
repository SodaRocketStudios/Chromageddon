using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace SRS.RandomOutcomeGenerator
{
	public class DistributionCreatorWindow : EditorWindow
	{
		private List<Outcome> outcomes = new List<Outcome>();

		private string saveLocation;
		private string lastSaveLocation = "Assets";

		private string fileName = "New Distribution";

		[MenuItem("Random Outcome Generator/Create New Distribution")]
		private static void ShowWindow()
		{
			var window = GetWindow<DistributionCreatorWindow>();
			window.titleContent = new GUIContent("Distribution Creator");
			window.Show();
			window.minSize = new Vector2(500, 250);
		}

		private void OnGUI()
		{
			if(GUILayout.Button("Add Outcome"))
			{
				outcomes.Add(new Outcome());
			}

			float remainingProbability = 100;
			for(int i = 0; i < outcomes.Count; i++)
			{
				GUILayout.BeginHorizontal();
				outcomes[i].Name = GUILayout.TextField(outcomes[i].Name, GUILayout.Width(150));
				outcomes[i].Probability = EditorGUILayout.Slider(outcomes[i].Probability, 0, remainingProbability);
				GUILayout.EndHorizontal();

				remainingProbability -= outcomes[i].Probability;
			}

			if(GUILayout.Button("Remove Outcome"))
			{
				outcomes.RemoveAt(outcomes.Count-1);
			}

			GUILayout.BeginHorizontal();
			GUILayout.Label("Name");
			fileName = EditorGUILayout.TextField(fileName);
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label("Save Location");
			string temp = EditorGUILayout.TextField(saveLocation);
			GUILayout.EndHorizontal();

			if(GUILayout.Button("Browse"))
			{
				temp = EditorUtility.OpenFolderPanel("Select Save Location", lastSaveLocation, "");
			}

			if(string.IsNullOrEmpty(temp) == false)
			{
				saveLocation = temp;
				lastSaveLocation = temp;
			}

			if(GUILayout.Button("Create Distribution"))
			{
				Distribution distribution = ScriptableObject.CreateInstance(typeof(Distribution)) as Distribution;
				AssetDatabase.CreateAsset(distribution, $"Assets/{saveLocation}/{fileName}.asset");
				AssetDatabase.SaveAssets();
				AssetDatabase.Refresh();

				distribution.populateOutcomes(outcomes);
			}
		}
	}
}