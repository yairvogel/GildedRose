using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.ItemUpdaters
{
    [CustomItemUpdater("Backstage passes to a TAFKAL80ETC concert")]
    class BackstagePassUpdater : IItemUpdater
    {
        private Item item;

        public BackstagePassUpdater(Item item)
        {
            this.item = item;
        }

        public void Update()
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            else
            {
                UpdateNonExpired();
            }

            item.SellIn--;
        }

        private void UpdateNonExpired()
        {
            if (item.SellIn < 6)
            {
                AddWithBound(3);
            }
            else if (item.SellIn < 11)
            {
                AddWithBound(2);
            }
            else
            {
                AddWithBound(1);
            }
        }

        private void AddWithBound(int add, int bound = 50)
        {
            if (item.Quality + add > bound)
            {
                item.Quality = bound;
            }
            else
            {
                item.Quality += add;
            }
        }
    }
}
