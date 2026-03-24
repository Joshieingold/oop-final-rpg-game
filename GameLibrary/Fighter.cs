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
        public int Attack { get; set; }
        public int Defense { get; set; }
        public List<IAbility> Abilities { get; set; }
        public Fighter()
        {
            MaxHealth = 100;
            MaxMana = 100;
            Defense = 40;
            Attack = 20;
            Health = MaxHealth;
            Mana = MaxMana;
        }
        public void UseAbility(IAbility chosenAbility, Fighter target)
        {
            if (chosenAbility is DamageAbility da)
            {
                da.Use(this, target);
            }
            else if (chosenAbility is HealthAbility ha)
            {
                ha.Use(this, target);
            }
            else if (chosenAbility is BuffAbility ba)
            {
                ba.Use(this, target);
            }
        }
        public bool ValidateAbility(IAbility chosenAbility)
        {
            if (this.Mana - chosenAbility.GetManaCost() < 0) return false;
            if (!this.Abilities.Contains(chosenAbility)) return false;
            return true;
        }
    }
}
