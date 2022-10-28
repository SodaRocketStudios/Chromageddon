using UnityEngine;
using UnityEditor;

namespace SRS.StatSystem
{
	[CustomEditor(typeof(BaseCharacterStats))]
	public class BaseCharacterDataEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if(GUILayout.Button("Populate Stats"))
			{
				(target as BaseCharacterStats).PopulateStats();
			}
		}
	}
}