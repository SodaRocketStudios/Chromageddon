using UnityEngine;
using UnityEditor;

namespace SRS.StatusEffects
{
	[CustomEditor(typeof(EffectDataObject))]
	[CanEditMultipleObjects]
	public class EffectDataEditor : Editor
	{
		private new SerializedProperty name;
		private SerializedProperty intensity;
		private SerializedProperty isTicking;
		private SerializedProperty tickDelay;
		private SerializedProperty modifiesStat;
		private SerializedProperty affectedStat;
		private SerializedProperty affectedModifier;

		private void OnEnable()
		{
			name = serializedObject.FindProperty("Name");
			intensity = serializedObject.FindProperty("Intensity");
			isTicking = serializedObject.FindProperty("IsTicking");
			tickDelay = serializedObject.FindProperty("TickDelay");
			modifiesStat = serializedObject.FindProperty("ModifiesStat");
			affectedStat = serializedObject.FindProperty("AffectedStat");
			affectedModifier = serializedObject.FindProperty("AffectedModifier");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(name);
			EditorGUILayout.PropertyField(intensity);
			EditorGUILayout.PropertyField(isTicking);
			if(isTicking.boolValue)
			{
				EditorGUILayout.PropertyField(tickDelay);
			}


			EditorGUILayout.PropertyField(modifiesStat);
			if(modifiesStat.boolValue)
			{
				EditorGUILayout.PropertyField(affectedStat);
				EditorGUILayout.PropertyField(affectedModifier);
			}
			
			serializedObject.ApplyModifiedProperties();
		}
	}
}