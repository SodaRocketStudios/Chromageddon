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

			Rect labelRect = new Rect(container.x, container.y, 80, 18);
			Rect nameRect = new Rect(container.x, container.y + 20, 200, 18);
			EditorGUI.LabelField(labelRect, "Stat Name:");
			EditorGUI.PropertyField(nameRect, nameProperty, GUIContent.none);

			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			Rect baseValueRect = new Rect(container.x, container.y + 40, 30, 18);
			Rect multiplyRect = new Rect(container.x + 32, container.y + 40, 10, 18);
			Rect percentageRect = new Rect(container.x + 44, container.y + 40, 30, 18);
			Rect equalRect = new Rect(container.x + 76, container.y + 40, 40, 18);

			var baseProperty = property.FindPropertyRelative("baseValue");
			var percentageProperty = property.FindPropertyRelative("percentageModifier");
			float finalValue = baseProperty.floatValue*percentageProperty.floatValue*.01f;

			EditorGUI.PropertyField(baseValueRect, baseProperty, GUIContent.none);
			EditorGUI.LabelField(multiplyRect, "x");
			EditorGUI.PropertyField(percentageRect, percentageProperty, GUIContent.none);
			EditorGUI.LabelField(equalRect, $"% = {finalValue}");

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return 60;
		}
	}

	
}