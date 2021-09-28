
namespace GildedRose.Console.ItemUpdaters
{
    class ConjuredItemUpdater : IItemUpdater
    {
        private Item item;

        public ConjuredItemUpdater(Item item)
        {
            this.item = item;
        }

        public void Update()
        {
            if (item.SellIn > 0)
            {
                LowerWithBound(2);
            }
            else
            {
                LowerWithBound(4);
            }
            item.SellIn--;
        }

        private void LowerWithBound(int amount, int bound = 0)
        {
            if (item.Quality - amount < bound)
            {
                item.Quality = bound;
            }
            else
            {
                item.Quality -= amount;
            }
        }
    }
}
