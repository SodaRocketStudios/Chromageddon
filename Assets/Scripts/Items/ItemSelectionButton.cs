using System;
using UnityEngine;

namespace SRS.Items
{
	public class ItemSelectionButton : MonoBehaviour
	{
		private Item item;
		public Item Item {get; set;}

		public Action<Item> OnSelect;

		public void Select()
		{
			OnSelect?.Invoke(item);
		}
	}
}