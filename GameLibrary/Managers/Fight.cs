using Core.Entities;
using Core.ItemsAndAbilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Managers
{
    public class Fight
    {
        private Fighter attacker { get; set; }
        private Fighter defender { get; set; }

        public Fight(Fighter inAttacker, Fighter inDefender, IAbility inAbility)
        {
            attacker = inAttacker;
            defender = inDefender;
            attacker.UseAbility(inAbility, defender);
        }
        public List<Fighter> GetUpdatedFighters()
        {
            return new List<Fighter>() { attacker,defender};
        }
    }
}
