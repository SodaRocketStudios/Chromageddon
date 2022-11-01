using System;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.ItemSystem
{
	public class ItemPickup : MonoBehaviour
	{
		const int NUMBER_OF_OPTIONS = 3;

        System.Random randomGenerator = new System.Random(System.DateTime.Now.Millisecond);

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
            {
				// To Do -- Determine item rarity. Probably needs to be set when item drops to change prefab.
                List<Item> itemOptions = GetItemOptions(ItemRarity.Common);

                ItemSelectionPanel.Instance.GenerateSelectionPanel(itemOptions, other.GetComponent<Inventory>());

                // To Do -- Replace destroy with object pooling solution
                Destroy(gameObject);
            }
        }

        private List<Item> GetItemOptions(ItemRarity rarity)
        {
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

                itemOptions.Add(ItemDatabase.Instance.GetRandomItem(rarity, category));
            }

            return itemOptions;
        }
    }
}