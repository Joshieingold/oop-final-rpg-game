using Core.ItemsAndAbilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Managers
{
    public class ShopManager
    {
        public int CurrentRollCost { get; set; }
        public List<IShopItem> AvailableItems { get; set; }
        public ShopManager()
        {
            CurrentRollCost = 1;
            AvailableItems = new List<IShopItem>(); //PLACEHOLDER
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
