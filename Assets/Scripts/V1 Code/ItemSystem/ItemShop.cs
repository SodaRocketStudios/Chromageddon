using System.Collections.Generic;
using System.Linq;
using SRS.Extensions;

namespace SRS.ItemSystem
{
    public class ItemShop
    {
        public ItemShop()
        {
            
        }

        public Item GetItem(int points)
        {
            return ItemDatabase.Instance.GetItems().Where(item => item.Cost <= points).ToList().GetRandom();
        }
    }
}
