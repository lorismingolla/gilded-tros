
namespace GildedTros.App.Items
{
    public class StandardItem : BaseItem
    {
        public StandardItem(Item item) : base(item)
        {
        }

        public override void Update()
        {
            Update(1);
        }

        protected void Update(int decrementMultiplier)
        {
            for (int i = 0; i < decrementMultiplier; i++)
            {
                DecrementQuality();
            }

            if (SellInUnderOrEqual(0))
            {
                for (int i = 0; i < decrementMultiplier; i++)
                {
                    DecrementQuality();
                }
            }

            DecrementSellIn();
        }
    }
}
