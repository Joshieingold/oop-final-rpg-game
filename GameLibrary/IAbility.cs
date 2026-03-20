using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IAbility : IShopItem
    {
        public void Use()
        {
            return;
        }
    }
}
