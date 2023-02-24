using System;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.ItemSystem
{
	public class ItemDrop : MonoBehaviour
	{
		const int NUMBER_OF_OPTIONS = 3;

        public delegate void OnPickupHandler(ItemDrop drop);
        public event OnPickupHandler OnPickup;

        [SerializeField] private RarityDistribution rarityDistribution;

        [SerializeField] private List<Color> rarityColors;

        private System.Random randomGenerator = new System.Random(Guid.NewGuid().GetHashCode());

        private ItemRarity rarity;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            rarity = rarityDistribution.GetRandom();
            spriteRenderer.color = rarityColors[(int)rarity];
        }

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
            {
                if(other.isTrigger) return;
                
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