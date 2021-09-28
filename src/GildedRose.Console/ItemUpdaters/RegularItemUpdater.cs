
namespace GildedRose.Console.ItemUpdaters
{
    class RegularItemUpdater : IItemUpdater
    {
        private readonly Item item;

        public RegularItemUpdater(Item item)
        {
            this.item = item;
        }

        public void Update()
        {
            if (item.SellIn > 0)
            {
                UpdateNonExpired();
            }
            else
            {
                UpdateExpired();
            }

            item.SellIn--;
        }

        private void UpdateNonExpired()
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }

        private void UpdateExpired()
        {
            if (item.Quality > 1)
            {
                item.Quality -= 2;
            }
            else
            {
                item.Quality = 0;
            }
        }
    }
}
