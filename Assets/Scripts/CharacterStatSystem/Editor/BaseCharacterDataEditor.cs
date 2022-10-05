using UnityEngine;
using UnityEditor;

namespace SRS.Stats
{
	[CustomEditor(typeof(BaseCharacterData))]
	public class BaseCharacterDataEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if(GUILayout.Button("Populate Stats"))
			{
				(target as BaseCharacterData).PopulateStats();
			}
		}
	}
}