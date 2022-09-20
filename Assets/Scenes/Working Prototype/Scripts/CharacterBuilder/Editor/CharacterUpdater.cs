using UnityEngine;
using UnityEditor;
using SRS.Stats;

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
				Debug.Log(guid);
				string assetPath = AssetDatabase.GUIDToAssetPath(guid);
				BaseCharacterData baseCharacterData = AssetDatabase.LoadAssetAtPath<BaseCharacterData>(assetPath);
				baseCharacterData.PopulateStats();
				Debug.Log($"Updated data for {baseCharacterData.name}.");
			}
		}
	}
}