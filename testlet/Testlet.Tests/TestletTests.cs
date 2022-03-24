using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Testlet.Tests
{
    public class TestletTests
    {
        private Testlet _testlet;
        private readonly Item[] items = {
            new Item {ItemId = "1", ItemType = ItemTypeEnum.Pretest},
            new Item {ItemId = "2", ItemType = ItemTypeEnum.Pretest},
            new Item {ItemId = "3", ItemType = ItemTypeEnum.Pretest},
            new Item {ItemId = "4", ItemType = ItemTypeEnum.Pretest},
            new Item {ItemId = "5", ItemType = ItemTypeEnum.Operational},
            new Item {ItemId = "6", ItemType = ItemTypeEnum.Operational},
            new Item {ItemId = "7", ItemType = ItemTypeEnum.Operational},
            new Item {ItemId = "8", ItemType = ItemTypeEnum.Operational},
            new Item {ItemId = "9", ItemType = ItemTypeEnum.Operational},
            new Item {ItemId = "10", ItemType = ItemTypeEnum.Operational},
        };

        public TestletTests()
        {
            this._testlet = new Testlet("testlet1", items.ToList());
            this._testlet.Randomize();
        }

        [Fact]
        public void TestletListIsOfSize10()
        {
            Assert.True(_testlet.GetItems().Count == this.items.Length);
        }

        [Fact]
        public void TestletHasAllMockedItems()
        {
            var testletItems = this._testlet.GetItems();
            bool allItemsArePresent = true;
            foreach (Item item in this.items)
            {
                if (!testletItems.Contains(item))
                {
                    allItemsArePresent = false;
                }
            }
            Assert.True(allItemsArePresent);
        }

        [Fact]
        public void FirstTwoItemsArePretest()
        {
            var testletItems = this._testlet.GetItems();
            Assert.True(testletItems[0].ItemType == ItemTypeEnum.Pretest &&
                        testletItems[1].ItemType == ItemTypeEnum.Pretest);
        }

        [Fact]
        public void TestletItemsHaveDifferentOrder()
        {
            bool isOrderDifferent = false;
            var testletItems = this._testlet.GetItems();
            for (int i = 0; i < testletItems.Count; ++i)
            {
                if (testletItems[i].ItemId != this.items[i].ItemId &&
                    testletItems[i].ItemType != this.items[i].ItemType)
                {
                    isOrderDifferent = true;
                }
            }

            Assert.True(isOrderDifferent);
        }
    }
}
