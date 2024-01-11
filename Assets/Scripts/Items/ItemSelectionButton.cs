using UnityEngine;

namespace SRS.Items
{
	public class ItemSelectionButton : MonoBehaviour
	{
		private Item item;
		public Item Item {get; set;}

		private Inventory targetInventory;
		public Inventory TargetInventory {get; set;}

		public void HandleClick()
		{
			targetInventory.Add(item);
		}
	}
}