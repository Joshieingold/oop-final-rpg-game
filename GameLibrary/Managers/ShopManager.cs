using Core.Factories;
using Core.ItemsAndAbilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Managers
{
    public class ShopManager
    {
        /////////////////
        // Constructor //
        /////////////////
        public ShopManager()
        {
            CurrentRollCost = 1;
            Roll(); // Initialize with random values
        }
       
        ////////////////
        // Properties //
        ////////////////
        public int CurrentRollCost { get; set; } // Cost for the player to roll.
        public List<IShopItem> AvailableAbilities { get; private set; } 
        public List<IShopItem> AvailableStatItems { get; private set; } // Not yet containing stat items.

        /////////////
        // Methods //
        /////////////
        private void IncreaseRollCost() // Applies exponential growth to the cost of rolling.
        {
            CurrentRollCost = CurrentRollCost * 2;
        }
        public void Roll() // Gets and sets the values of the current availiable items.
        {
            AvailableAbilities = new List<IShopItem>();
            AvailableAbilities.AddRange(AbilityFactory.GetXNewAbilities(3));
            AvailableStatItems = new List<IShopItem>();
            AvailableStatItems.AddRange(AbilityFactory.GetXNewAbilities(3)); // NOT YET IMPLEMENTED SO ARE ABILITIES.
            IncreaseRollCost();
        }
    }
}
