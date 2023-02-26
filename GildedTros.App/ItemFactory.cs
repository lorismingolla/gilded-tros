using GildedTros.App.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App
{
    public class ItemFactory
    {
        private Dictionary<string, BaseItem> ItemTypeDict = new Dictionary<string, BaseItem>();
        private const string WINE_NAME = "Good Wine";
        private const string BACKSTAGE_PASS_REFACTOR_NAME = "Backstage passes for Re:factor";
        private const string BACKSTAGE_PASS_HAXX_NAME = "Backstage passes for HAXX";
        private const string BDAWG_NAME = "B-DAWG Keychain";
        private const string DUPLICATE_CODE = "Duplicate Code";
        private const string LONG_METHODS = "Long Methods";
        private const string UGLY_VARS = "Ugly Variable Names";
        public ItemFactory(Item item)
        {
            ItemTypeDict[WINE_NAME] = new GoodWine(item);
            ItemTypeDict[BACKSTAGE_PASS_REFACTOR_NAME] = new BackstagePass(item);
            ItemTypeDict[BACKSTAGE_PASS_HAXX_NAME] = new BackstagePass(item);
            ItemTypeDict[BDAWG_NAME] = new BDawgKeychain(item);
            ItemTypeDict[DUPLICATE_CODE] = new SmellyItem(item);
            ItemTypeDict[LONG_METHODS] = new SmellyItem(item);
            ItemTypeDict[UGLY_VARS] = new SmellyItem(item);
        }

        public BaseItem ToTypedItem(Item item)
        {
            if (ItemTypeDict.Keys.Contains(item.Name))
            {
                return ItemTypeDict[item.Name];
            }
            return new StandardItem(item);
        }
    }
}
