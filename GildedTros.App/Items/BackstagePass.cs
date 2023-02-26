
namespace GildedTros.App.Items
{
    public class BackstagePass : BaseItem
    {
        public BackstagePass(Item item) : base(item)
        {
        }

        public override void Update()
        {
            IncrementQuality();

            if (SellInUnderOrEqual(10))
            {
                IncrementQuality();
            }

            if (SellInUnderOrEqual(5))
            {
                IncrementQuality();
            }
            
            if (SellInUnderOrEqual(0))
            {
                Item.Quality = 0;
            }
            DecrementSellIn();
        }
    }
}
