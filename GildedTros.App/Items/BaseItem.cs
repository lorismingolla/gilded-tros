
namespace GildedTros.App
{
    public abstract class BaseItem
    {
        public static Item Item { get; set; }
        private const int MAX_QUALITY = 50;

        public BaseItem(Item item)
        {
            Item = item;
        }

        public abstract void Update();

        protected static void IncrementQuality()
        {
            if (Item.Quality < MAX_QUALITY)
            {
                Item.Quality++;
            }
        }

        protected static void DecrementQuality()
        {
            if (Item.Quality > 0)
            {
                Item.Quality--;
            }
        }

        protected static bool SellInUnderOrEqual(int minSellIn)
        {
            return Item.SellIn <= minSellIn;
        }
        protected static void DecrementSellIn()
        {
            Item.SellIn = Item.SellIn - 1;
        }
    }
}
