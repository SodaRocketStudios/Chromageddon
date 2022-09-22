using UnityEngine;
using UnityEditor;
using SRS.RandomOutcomeGenerator;
using System.Collections.Generic;

namespace SRS
{
	public class TestWindow : EditorWindow
	{
		private Object dist;

		private int iterations;

		[MenuItem("Window/Test Window")]
		private static void ShowWindow()
		{
			var window = GetWindow<TestWindow>();
			window.titleContent = new GUIContent("Test");
			window.Show();
		}
		
		private void OnGUI()
		{
			dist = EditorGUILayout.ObjectField(dist, typeof(Object), false);

			Distribution distribution = dist as Distribution;

			if(GUILayout.Button("Get Random Outcome"))
			{
				Debug.Log(OutcomeGenerator.GetOutcome(distribution).Name);
			}
			if(GUILayout.Button("Get 100 Random Outcomes"))
			{
				for(int i = 0; i < 100; i++)
				{
					Debug.Log(OutcomeGenerator.GetOutcome(distribution).Name);
				}
			}
			if(GUILayout.Button("Get 1000 Random Outcomes"))
			{
				for(int i = 0; i < 1000; i++)
				{
					Debug.Log(OutcomeGenerator.GetOutcome(distribution).Name);
				}
			}

			iterations = EditorGUILayout.IntField(iterations);

			if(GUILayout.Button("Probability test"))
			{
				Dictionary<string, int> outcomeList = new Dictionary<string, int>();

				for(int i = 0; i < iterations; i++)
				{
					string outcomeName = OutcomeGenerator.GetOutcome(distribution).Name;

					if(string.IsNullOrEmpty(outcomeName)) Debug.Log("Null");

					if(outcomeList.ContainsKey(outcomeName))
					{
						outcomeList[outcomeName]++;
					}
					else
					{
						outcomeList[outcomeName] = 1;
					}
				}

				foreach(KeyValuePair<string, int> outcome in outcomeList)
				{
					Debug.Log($"{outcome.Key}: {1.0f*outcome.Value/iterations}");
				}
			}
		}
	}

	
}