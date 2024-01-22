using System;
using TMPro;
using UnityEngine;

namespace SRS.Items
{
	public class ItemSelectionButton : MonoBehaviour
	{
		private Item item;
		public Item Item
		{
			get => item;
			set
			{
				item = value;
				Draw();
			}
		}

		public Action<Item> OnSelect;

		[SerializeField] private TMP_Text nameText;

		public void Select()
		{
			OnSelect?.Invoke(item);
		}

		private void Draw()
		{
			nameText.text = item.Name;
		}
	}
}