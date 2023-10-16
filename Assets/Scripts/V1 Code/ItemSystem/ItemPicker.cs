using System;
using System.Collections.Generic;
using UnityEngine;

namespace SRS.ItemSystem
{
    public class ItemPicker : MonoBehaviour
    {
        [SerializeField] private bool ChooseFromAllCategories = true;
        [SerializeField] private int NumberOfChoices = 3;

        private int NumberOfCategories;

        private void Start()
        {
            NumberOfCategories = Enum.GetNames(typeof(ItemCategory)).Length;

            if(ChooseFromAllCategories)
            {
                NumberOfChoices = NumberOfCategories;
            }
        }
        public List<Item> PickItems()
        {
            ItemCategory[] categories = new ItemCategory[NumberOfChoices];

            if(ChooseFromAllCategories)
            {
                int i = 0;
                foreach(ItemCategory category in Enum.GetValues(typeof(ItemCategory)))
                {
                    categories[i] = category;
                    i++;
                }
            }
            else
            {
                // Get Random Categories without duplicates
            }

            // Get Random Rarities based on Level

            List<Item> itemChoices = new List<Item>();

            foreach(ItemCategory category in categories)
            {
                itemChoices.Add(ItemDatabase.Instance.GetRandomItem(ItemRarity.Common, category));
            }

            return itemChoices;
        }
    }
}
