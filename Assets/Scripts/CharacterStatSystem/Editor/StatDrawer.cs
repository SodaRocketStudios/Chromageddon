using UnityEngine;
using UnityEditor;

namespace SRS.Stats
{	
	[CustomPropertyDrawer(typeof(Stat))]
	public class StatDrawer: PropertyDrawer
	{
		public override void OnGUI(Rect container, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(container, label, property);

			Rect labelRect = new Rect(container.x, container.y, 200, 18);
			EditorGUI.LabelField(labelRect, label);

			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			Rect openParansRect = new Rect(container.x, container.y + 20, 5, 18);
			Rect baseValueRect = new Rect(container.x + 10, container.y + 20, 30, 18);
			Rect addRect1 = new Rect(container.x + 42, container.y + 20, 10, 18);
			Rect additiveRect = new Rect(container.x + 54, container.y + 20, 30, 18);
			Rect closeParansRect = new Rect(container.x + 89, container.y + 20, 5, 18);
			Rect multiplyRect = new Rect(container.x + 96, container.y + 20, 10, 18);
			Rect multiplicativeRect = new Rect(container.x + 108, container.y + 20, 30, 18);
			Rect addRect2 = new Rect(container.x + 140, container.y + 20, 10, 18);
			Rect flatRect = new Rect(container.x + 152, container.y + 20, 30, 18);
			Rect equalRect = new Rect(container.x + 184, container.y + 20, 40, 18);

			var baseProperty = property.FindPropertyRelative("baseValue");
			var additiveProperty = property.FindPropertyRelative("additiveModifier");
			var multiplicativeProperty = property.FindPropertyRelative("multiplicativeModifier");
			var flatProperty = property.FindPropertyRelative("flatModifier");
			float finalValue = (baseProperty.floatValue + additiveProperty.floatValue)*multiplicativeProperty.floatValue + flatProperty.floatValue;

			EditorGUI.LabelField(openParansRect, "(");
			EditorGUI.PropertyField(baseValueRect, baseProperty, GUIContent.none);
			EditorGUI.LabelField(addRect1, "+");
			EditorGUI.PropertyField(additiveRect, additiveProperty, GUIContent.none);
			EditorGUI.LabelField(closeParansRect, ")");
			EditorGUI.LabelField(multiplyRect, "x");
			EditorGUI.PropertyField(multiplicativeRect, multiplicativeProperty, GUIContent.none);
			EditorGUI.LabelField(addRect2, "+");
			EditorGUI.PropertyField(flatRect, flatProperty, GUIContent.none);
			EditorGUI.LabelField(equalRect, $"= {finalValue}");

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return 40;
		}
	}

	
}