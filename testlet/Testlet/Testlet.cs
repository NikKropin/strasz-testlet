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
            throw new NotImplementedException("Not implemented");
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
