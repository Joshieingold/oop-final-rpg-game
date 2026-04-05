using Core.Entities;

namespace Core.ItemsAndAbilities
{
    public class StatItem : IShopItem // NOT IMPLEMENTED YET //
    {
        /////////////////
        // Constructor //
        /////////////////
        public StatItem()
        {
            Sprite = "ShopItems/PlaceHolder.png"; 
        }

        ////////////////
        // Properties //
        ////////////////
        public string Name { get; set; }
        public int Price { get; set; }
        public string Sprite { get; set; }

        /////////////
        // Methods //
        /////////////
        private void Use(Fighter player)
        {
            return;
        }
        public void Buy(Fighter player)
        {
            if (player is Player p)
            {
                // Take the money from the player and do the use;
                Use(p);
            }
        }
    }
}
