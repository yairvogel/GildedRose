using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class BackstagePassesTests
    {
        private Program app;
        public BackstagePassesTests()
        {
            app = new Program();
        }
        [Fact]
        public void BackstagePassesIncreaseByTwo10DaysBeforeSellIn()
        {
            Item pass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20, SellIn = 10 };
            var items = new List<Item> { pass };

            app.UpdateQuality(items);

            Assert.Equal(22, pass.Quality);
            Assert.Equal(9, pass.SellIn);
        }

        [Fact]
        public void BackstagePassesIncreaseByOneMoreThan10DaysBeforeSellIn()
        {
            Item pass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20, SellIn = 11 };
            var items = new List<Item> { pass };

            app.UpdateQuality(items);

            Assert.Equal(21, pass.Quality);
            Assert.Equal(10, pass.SellIn);
        }

        [Fact]
        public void BackstagePassesIncreaseByThree5DaysBeforeSellIn()
        {
            Item pass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20, SellIn = 5 };
            var items = new List<Item> { pass };

            app.UpdateQuality(items);

            Assert.Equal(23, pass.Quality);
            Assert.Equal(4, pass.SellIn);
        }

        [Fact]
        public void BackstagePassesDoNotPassMaxQuality()
        {
            Item regular = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 50, SellIn = 15 };
            Item close = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 49, SellIn = 10 };
            Item closer = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 48, SellIn = 5 };
            var items = new List<Item> { regular, close, closer };

            app.UpdateQuality(items);

            Assert.Equal(50, regular.Quality);
            Assert.Equal(50, close.Quality);
            Assert.Equal(50, closer.Quality);
        }

        [Fact]
        public void BackstagePassesTurnToZeroAfterWhenExpired()
        {
            Item pass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20, SellIn = 0 };
            var items = new List<Item> { pass };

            app.UpdateQuality(items);

            Assert.Equal(0, pass.Quality);
        }
    }
}
