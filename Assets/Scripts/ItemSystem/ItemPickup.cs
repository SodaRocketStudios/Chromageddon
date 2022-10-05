using System;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.ItemSystem
{
	public class ItemPickup : MonoBehaviour
	{
		const int NUMBER_OF_OPTIONS = 3;

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
            {
				// Determine item rarity
                List<Item> itemOptions = GetItemOptions(ItemRarity.Common);
                // Pause the game and open the item selection screen with the item options.
                ItemSelectionPanel.Instance.GenerateButtons(itemOptions);
            }
        }

        private List<Item> GetItemOptions(ItemRarity rarity)
        {
			System.Random randomGenerator = new System.Random(System.DateTime.Now.Millisecond);

			List<Item> itemOptions = new List<Item>(NUMBER_OF_OPTIONS);
			List<ItemCategory> categories = new List<ItemCategory>(NUMBER_OF_OPTIONS);

            for (int i = 0; i < NUMBER_OF_OPTIONS; i++)
            {
                ItemCategory category;

                do
                {
                    category = (ItemCategory)randomGenerator.Next(Enum.GetNames(typeof(ItemCategory)).Length);
                }
                while (categories.Contains(category));
                categories.Add(category);

                itemOptions.Add(ItemDatabase.Instance.GetRandomItem(category));
            }

            return itemOptions;
        }
    }
}