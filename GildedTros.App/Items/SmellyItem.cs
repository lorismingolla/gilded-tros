
namespace GildedTros.App.Items
{
    public class SmellyItem : StandardItem
    {
        public SmellyItem(Item item) : base(item)
        {
        }

        public override void Update()
        {
            Update(2);
        }
    }
}
