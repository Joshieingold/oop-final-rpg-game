using Core.Factories;
using Core.ItemsAndAbilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Managers
{
    public class ShopManager
    {
        public int CurrentRollCost { get; set; }
        public List<IShopItem> AvailableAbilities { get; private set; }
        public List<IShopItem> AvailableStatItems { get; private set; }
        public ShopManager()
        {
            CurrentRollCost = 1;
            Roll();
        }
        private void IncreaseRollCost()
        {
            CurrentRollCost = CurrentRollCost * 2;
        }
        public void Roll()
        {
            AvailableAbilities = new List<IShopItem>();
            AvailableAbilities.AddRange(new AbilityFactory().GetXNewAbilities(3));
            AvailableStatItems = new List<IShopItem>();
            AvailableStatItems.AddRange(new AbilityFactory().GetXNewAbilities(3)); // FIX ME THIS SHOULD BE THE Stat items that are not implemented yet
            IncreaseRollCost();
        }
    }
}
