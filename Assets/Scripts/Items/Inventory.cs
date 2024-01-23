using UnityEngine;
using SRS.Stats;
using System.Collections.Generic;

namespace SRS.Items
{
	public class Inventory : MonoBehaviour
	{
		private StatContainer stats;
		
		private List<Item> items = new();

		private void Awake()
		{
			stats = GetComponent<StatContainer>();
		}

		public void Add(Item item)
		{
			if(item == null)
			{
				return;
			}
			
			items.Add(item);
			item.Apply(stats);
		}

		private void Remove(Item item)
		{
			if(items.Remove(item))
			{
				item.Remove(stats);
			}
		}
	}
}