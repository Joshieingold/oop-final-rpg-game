using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ShopManager
    {
        public int CurrentRollCost { get; set; }
        public List<IShopItem> AvailableItems { get; set; }
        public ShopManager(Fighter inPlayer)
        {
            CurrentRollCost = 1;
        }
        public void IncreaseRollCost()
        {
            CurrentRollCost = CurrentRollCost * 2;
        }
        public void Roll()
        {
            return;
        }
        public void Exit()
        {
            return;
        }
    }
}
