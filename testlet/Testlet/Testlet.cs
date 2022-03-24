using System;
using System.Collections.Generic;
using System.Linq;

namespace Testlet
{
    public class Testlet
    {
        public string TestletId;
        private List<Item> Items;
        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
        }
        public List<Item> GetItems()
        {
            return this.Items;
        }
        public List<Item> Randomize()
        {
            List<Item> randomizedItems = new List<Item>();
            var randomGenerator = new Random();

            var pretestItems = this.Items.Where(item => item.ItemType == ItemTypeEnum.Pretest).ToList();
            int firstPretestIndex = randomGenerator.Next(4);
            int secondPretestIndex = randomGenerator.Next(4);
            while (secondPretestIndex == firstPretestIndex)
            {
                secondPretestIndex = randomGenerator.Next(4);
            }

            randomizedItems.AddRange(new Item[]{ pretestItems[firstPretestIndex], pretestItems[secondPretestIndex] });

            var remainingItemsShuffled = this.Items
                    .Where(item => !randomizedItems.Any(i => i.ItemId == item.ItemId && i.ItemType == item.ItemType))
                    .OrderBy(i => randomGenerator.Next())
                    .ToList();
            randomizedItems.AddRange(remainingItemsShuffled);
            return randomizedItems;
        }
    }
    public class Item
    {
        public string ItemId;
        public ItemTypeEnum ItemType;
    }
    public enum ItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }
}
