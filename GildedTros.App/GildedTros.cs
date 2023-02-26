using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<Item> Items;

        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach(var item in Items)
            {
                var typedItem = new ItemFactory(item).ToTypedItem(item);
                typedItem.Update();
            }
        }

        //For Reference: UpdateQuality() before factory pattern.

        //public void UpdateQuality()
        //{
        //    foreach (var item in Items)
        //    {
        //        if (item.Name == BDAWG_NAME)
        //        {
        //            continue;
        //        }
        //        if (item.Name == WINE_NAME)
        //        {
        //            IncrementQuality(item);

        //            if (SellInUnderOrEqual(item, 0))
        //            {
        //                IncrementQuality(item);
        //            }
        //        }
        //        else if (item.Name == BACKSTAGE_PASS_REFACTOR_NAME
        //                || item.Name == BACKSTAGE_PASS_HAXX_NAME)
        //        {
        //            IncrementQuality(item);

        //            if (SellInUnderOrEqual(item, 10))
        //            {
        //                IncrementQuality(item);
        //            }

        //            if (SellInUnderOrEqual(item, 5))
        //            {
        //                IncrementQuality(item);
        //            }
        //            if (SellInUnderOrEqual(item, 0))
        //            {
        //                item.Quality = 0;
        //            }
        //        }
        //        else
        //        {
        //            DecrementQuality(item);
        //            if (SellInUnderOrEqual(item, 0))
        //            {
        //                DecrementQuality(item);
        //            }
        //        }

        //        DecrementSellIn(item); 
        //    }
        //}
    }
}
