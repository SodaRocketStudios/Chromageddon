using System;
using TMPro;
using UnityEngine;
using SRS.Stats;

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
			}
		}

		public Action<Item> OnSelect;

		[SerializeField] private TMP_Text nameText;

		[SerializeField] private TMP_Text descriptionText;

		public void Select()
		{
			OnSelect?.Invoke(item);
		}

		public void Draw(StatContainer playerStats, DescriptionFormat format)
		{
			nameText.text = item.Name;

			if(format == DescriptionFormat.Relative)
			{
				descriptionText.text = item.BuildDescription(playerStats);
				return;
			}

			descriptionText.text = item.BuildDescription();
		}
	}
}