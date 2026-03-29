using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ItemsAndAbilities
{
    public interface IAbility : IShopItem
    {
        public int GetManaCost();
        public void Use(Fighter attacker, Fighter defender);
    }
}
