using Core.Entities;

namespace Core.ItemsAndAbilities
{
    // Shop item interface.
    public interface IShopItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Sprite { get; set; }
        public abstract void Buy(Fighter player);
    }
}
