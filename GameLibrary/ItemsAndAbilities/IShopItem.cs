using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ItemsAndAbilities
{
    public interface IShopItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public abstract void Buy(Fighter player);
    }
}
