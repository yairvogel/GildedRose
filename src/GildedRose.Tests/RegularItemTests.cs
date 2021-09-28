using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class RegularItemTests
    {
        private Program app;
        public RegularItemTests()
        {
            app = new Program();
        }
        [Fact]
        public void UpdateRegularItemShouldDecrement()
        {
            Item item = new Item { Name = "Regular Name", Quality = 20, SellIn = 10 };
            IList<Item> items = new List<Item>() { item };

            app.UpdateQuality(items);

            Assert.Equal("Regular Name", item.Name);
            Assert.Equal(19, item.Quality);
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void SellInPricePassedShouldDegradeTwiceAsFast()
        {
            Item item = new Item { Name = "Regular Name", Quality = 20, SellIn = 0 };
            IList<Item> items = new List<Item>() { item };

            app.UpdateQuality(items);

            Assert.Equal(18, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }

        [Fact]
        public void ZeroQualityShouldNotBeNegative()
        {
            Item item = new Item { Name = "item", Quality = 0, SellIn = 2 };
            var items = new List<Item>() { item };

            app.UpdateQuality(items);

            Assert.Equal(0, item.Quality);
            Assert.Equal(1, item.SellIn);
        }

        [Fact]
        public void ZeroQualityAndExpiredShouldNotBeNegative()
        {
            Item item = new Item { Name = "item", Quality = 0, SellIn = -2 };
            var items = new List<Item>() { item };

            app.UpdateQuality(items);

            Assert.Equal(0, item.Quality);
            Assert.Equal(-3, item.SellIn);
        }
    }
}
