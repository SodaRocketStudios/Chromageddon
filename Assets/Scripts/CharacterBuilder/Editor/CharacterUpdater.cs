using UnityEngine;
using UnityEditor;
using SRS.StatSystem;

namespace SRS.CharacterBuilder
{
	public class CharacterUpdater
	{
		[MenuItem("Character Builder/Update Character Data")]
		public static void UpdateCharacterData()
		{
			string[] guids = AssetDatabase.FindAssets($"t:BaseCharacterData");

			foreach(string guid in guids)
			{
				string assetPath = AssetDatabase.GUIDToAssetPath(guid);
				BaseCharacterStats baseCharacterData = AssetDatabase.LoadAssetAtPath<BaseCharacterStats>(assetPath);
				baseCharacterData.PopulateStats();
				Debug.Log($"Updated data for {baseCharacterData.name}.");
			}
		}
	}
}