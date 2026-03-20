using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class StatItem : IShopItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        private void Use(Fighter player)
        {
            return;
        }
        public void Buy(Fighter player)
        {
            if (player is Player p)
            {
                // Take the money from the player and do the use;
                Use(player);
                return;
            }
            return;
        }
    }
}
