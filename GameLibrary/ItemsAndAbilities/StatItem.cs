using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ItemsAndAbilities
{
    public class StatItem : IShopItem
    {
        public StatItem()
        {
            Sprite = "ShopItems/PlaceHolder.png"; // DO I EVEN NEED TO SAY IT?
        }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Sprite { get; set; }
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
                return;
            }
            return;
        }
    }
}
