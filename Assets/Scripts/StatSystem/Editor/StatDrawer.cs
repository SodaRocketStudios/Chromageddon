using UnityEngine;
using UnityEditor;

namespace SRS.StatSystem
{	
	[CustomPropertyDrawer(typeof(Stat))]
	public class StatDrawer: PropertyDrawer
	{
		public override void OnGUI(Rect container, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(container, label, property);

			var nameProperty = property.FindPropertyRelative("name");

			Rect labelRect = new Rect(container.x, container.y, 62, 18);
			Rect nameRect = new Rect(container.x + 64, container.y, 150, 18);
			EditorGUI.LabelField(labelRect, "Stat name:");
			EditorGUI.PropertyField(nameRect, nameProperty, GUIContent.none);

			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			Rect openParansRect = new Rect(container.x - 20, container.y + 20, 5, 18);
			Rect baseValueRect = new Rect(container.x -10, container.y + 20, 30, 18);
			Rect addRect1 = new Rect(container.x + 22, container.y + 20, 10, 18);
			Rect additiveRect = new Rect(container.x + 34, container.y + 20, 30, 18);
			Rect closeParansRect = new Rect(container.x + 69, container.y + 20, 5, 18);
			Rect multiplyRect = new Rect(container.x + 76, container.y + 20, 10, 18);
			Rect percentageRect = new Rect(container.x + 88, container.y + 20, 30, 18);
			Rect equalRect = new Rect(container.x + 120, container.y + 20, 40, 18);

			var baseProperty = property.FindPropertyRelative("baseValue");
			var additiveProperty = property.FindPropertyRelative("additiveModifier");
			var percentageProperty = property.FindPropertyRelative("percentageModifier");
			float finalValue = (baseProperty.floatValue + additiveProperty.floatValue)*percentageProperty.floatValue*.01f;

			EditorGUI.LabelField(openParansRect, "(");
			EditorGUI.PropertyField(baseValueRect, baseProperty, GUIContent.none);
			EditorGUI.LabelField(addRect1, "+");
			EditorGUI.PropertyField(additiveRect, additiveProperty, GUIContent.none);
			EditorGUI.LabelField(closeParansRect, ")");
			EditorGUI.LabelField(multiplyRect, "x");
			EditorGUI.PropertyField(percentageRect, percentageProperty, GUIContent.none);
			EditorGUI.LabelField(equalRect, $"% = {finalValue}");

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return 40;
		}
	}

	
}