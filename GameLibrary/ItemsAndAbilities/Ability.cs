using Core.Entities;
using Core.ItemsAndAbilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Items
{
    public abstract class Ability : IAbility
    {
        public string Name { get; set; }
        public int ManaCost { get; set; } 
        public int Price { get; set; }
        public abstract void Use(Fighter attacker, Fighter defender);
        public virtual void Buy(Fighter player) 
        {
            player.Abilities.Add(this);
        }
        public int GetManaCost()
        {
            return ManaCost;
        }
    }
}
