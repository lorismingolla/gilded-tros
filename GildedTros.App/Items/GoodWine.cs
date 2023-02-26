
namespace GildedTros.App.Items
{
    public class GoodWine : BaseItem
    {
        public GoodWine(Item item) : base(item)
        {
        }

        public override void Update()
        {
            IncrementQuality();

            if (SellInUnderOrEqual(0))
            {
                IncrementQuality();
            }

            DecrementSellIn();
        }
    }
}
