using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SRS.ItemSystem
{
	public class ItemPickup : MonoBehaviour
	{
		const int NUMBER_OF_OPTIONS = 3;

        public ItemRarity rarity;

        public delegate void OnPickupHandler(ItemPickup pickup);
        public event OnPickupHandler OnPickup;

        private System.Random randomGenerator = new System.Random(System.DateTime.Now.Millisecond);

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
            {
                List<Item> itemOptions = GetItemOptions();

                ItemSelectionPanel.Instance.GenerateSelectionPanel(itemOptions, other.GetComponent<Inventory>());

                OnPickup?.Invoke(this);
            }
        }

        private List<Item> GetItemOptions()
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