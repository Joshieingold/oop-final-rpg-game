using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class Fighter
    {
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int MaxMana { get; set; }
        public int Mana { get; set; }
        public string Name { get; set; }
        public List<IAbility> Abilities { get; set; }
        public Fighter()
        {
            MaxHealth = 100;
            MaxMana = 100;
            Health = MaxHealth;
            Mana = MaxMana;
        }
        public void UseAbility()
        {
            return;
        }
    }
}
