
using System;

namespace GildedRose.Console.ItemUpdaters
{
    [CustomItemUpdater("Aged Brie")]
    class AgedBrieUpdater : IItemUpdater
    {
        private Item item;

        public AgedBrieUpdater(Item item)
        {
            this.item = item;
        }

        public void Update()
        {
            if (item.SellIn >= 0)
            {
                UpdateQualityNotExpired();
            }
            else
            {
                UpdateQualityExpired();
            }

            item.SellIn--;
        }

        private void UpdateQualityExpired()
        {
            if (item.Quality < 49)
            {
                item.Quality += 2;
            }
            else
            {
                item.Quality = 50;
            }
        }

        private void UpdateQualityNotExpired()
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }
}
