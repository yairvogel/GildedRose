using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class SulfurasTests
    {
        private Program app;
        public SulfurasTests()
        {
            app = new Program();
        }
        [Fact]
        public void SulfurasShouldNotChange()
        {
            Item sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 40, SellIn = 3 };
            var items = new List<Item> { sulfuras };

            app.UpdateQuality(items);

            Assert.Equal(40, sulfuras.Quality);
            Assert.Equal(3, sulfuras.SellIn);
        }

        [Fact]
        public void ExpiredSulfurasShouldNotChange()
        {
            Item sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 40, SellIn = 0 };
            var items = new List<Item> { sulfuras };

            app.UpdateQuality(items);

            Assert.Equal(40, sulfuras.Quality);
            Assert.Equal(0, sulfuras.SellIn);
        }
    }
}