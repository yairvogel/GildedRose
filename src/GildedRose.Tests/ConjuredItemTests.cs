
using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredItemTests
    {
        private Program app;

        public ConjuredItemTests()
        {
            app = new Program();
        }

        [Fact]
        public void ConjuredItemShouldDegradeTwiceAsFast()
        {
            Item item = new Item { Name = "Conjured Something", Quality = 30, SellIn = 10 };
            var items = new List<Item> { item };

            app.UpdateQuality(items);

            Assert.Equal(28, item.Quality);
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void ExpiredConjuredItemShouldDegradeFourTimesAsFast()
        {
            Item item = new Item { Name = "Conjured Something", Quality = 30, SellIn = 0 };
            var items = new List<Item> { item };

            app.UpdateQuality(items);

            Assert.Equal(26, item.Quality);
            Assert.Equal(-1, item.SellIn);
        }
    }
}
