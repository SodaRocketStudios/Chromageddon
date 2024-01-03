using System.Collections.Generic;
using UnityEngine;

namespace SRS.Items
{
	[CreateAssetMenu(fileName = "New Item Database", menuName = "Items/Database")]
	public class ItemDatabase : ScriptableObject
	{
		public List<Item> Items = new();
	}
}