using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IAbility : IShopItem
    {
        public int GetManaCost();
        public void Use(Fighter attacker, Fighter defender);
    }
}
