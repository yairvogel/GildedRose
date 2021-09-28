
using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class AgedBrieTests
    {
        private Program app;

        public AgedBrieTests()
        {
            app = new Program();
        }

        [Fact]
        public void AgedBrieQualityShouldIncrease()
        {
            Item brie = new Item { Name = "Aged Brie", Quality = 30, SellIn = 2 };
            var items = new List<Item>() { brie };

            app.UpdateQuality(items);

            Assert.Equal(31, brie.Quality);
            Assert.Equal(1, brie.SellIn);
        }

        [Fact]
        public void AgedBrieQualityShouldNotExceed50()
        {
            Item brie = new Item { Name = "Aged Brie", Quality = 50, SellIn = 2 };
            var items = new List<Item>() { brie };

            app.UpdateQuality(items);

            Assert.Equal(50, brie.Quality);
            Assert.Equal(1, brie.SellIn);
        }

        [Fact]
        public void ExpiredAgedBrieShouldIncreaseTwiceAsFast()
        {
            Item brie = new Item { Name = "Aged Brie", Quality = 30, SellIn = -2 };
            var items = new List<Item>() { brie };

            app.UpdateQuality(items);

            Assert.Equal(32, brie.Quality);
            Assert.Equal(-3, brie.SellIn);
        }
    }
}
