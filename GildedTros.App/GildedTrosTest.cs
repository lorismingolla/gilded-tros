using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void UpdateQualityDecrementsSellInAndQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 1 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void PassedSellDateQualityDegradeDouble()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 2 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(-2, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void QualityNeverUnderZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void GoodWineIncreasesInQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Good Wine", SellIn = 1, Quality = 2 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.True(Items[0].Quality > 2);
        }

        [Fact]
        public void ItemQualityNeverOver50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Good Wine", SellIn = 1, Quality = 50 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void LegendaryItemNeverDecreasesSellInOrQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "B-DAWG Keychain", SellIn = 1, Quality = 2 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void BackstagePassesIncrease2QualityBetween10And5SellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            for (int i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }
            Assert.Equal(10, Items[0].Quality);
        }

        [Fact]
        public void BackstagePassesIncrease3QualityUnder6SellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 5, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            for (int i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }
            Assert.Equal(15, Items[0].Quality);
        }

        [Fact]
        public void BackstagePassesQuality0AfterSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 0, Quality = 10 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();    
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void SmellyItemsDegradeDoubleSpeed()
        {
            const int startQuality = 15;
            const int startSellin = 1;
            const int standardEndQuality = 12;
            const int smellyEndQuality = 9;

            IList<Item> Items = new List<Item> {
                new Item { Name = "foo", SellIn = startSellin, Quality = startQuality },
                new Item { Name = "Duplicate Code", SellIn = startSellin, Quality = startQuality },
                new Item { Name = "Long Methods", SellIn = startSellin, Quality = startQuality },
                new Item { Name = "Ugly Variable Names", SellIn = startSellin, Quality = startQuality }
            };
            GildedTros app = new GildedTros(Items);
            for (int i = 0; i < 2; i++)
            {
                app.UpdateQuality();
            }
            Assert.Equal(standardEndQuality, Items[0].Quality);
            Assert.Equal(smellyEndQuality, Items[1].Quality);

        }
    }
}