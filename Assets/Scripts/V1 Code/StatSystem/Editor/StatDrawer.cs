using UnityEngine;
using UnityEditor;
using SRS.StatSystem;

namespace SRS.StatsEditor
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
			Rect equalRect = new Rect(container.x + 76, container.y + 40, 150, 18);

			var baseProperty = property.FindPropertyRelative("baseValue");
			var percentageProperty = property.FindPropertyRelative("percentageModifier");
			float finalValue = baseProperty.floatValue*percentageProperty.floatValue*.01f;

			EditorGUI.PropertyField(baseValueRect, baseProperty, GUIContent.none);
			EditorGUI.LabelField(multiplyRect, "x");
			EditorGUI.PropertyField(percentageRect, percentageProperty, GUIContent.none);
			EditorGUI.LabelField(equalRect, $"% = {finalValue}");

			var hasCapProperty = property.FindPropertyRelative("hasCap");
			var capProperty = property.FindPropertyRelative("cap");

			Rect hasCapTextRect = new Rect(container.x, container.y + 60, 95, 18);
			Rect hasCapRect = new Rect(container.x + 97, container.y + 60, 18, 18);
			Rect capRect = new Rect(container.x + 122, container.y + 60, 50, 18);

			EditorGUI.LabelField(hasCapTextRect, "Has a value cap:");
			EditorGUI.PropertyField(hasCapRect, hasCapProperty, GUIContent.none);

			if(hasCapProperty.boolValue)
			{
				EditorGUI.PropertyField(capRect, capProperty, GUIContent.none);
			}

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return 80;
		}
	}

	
}