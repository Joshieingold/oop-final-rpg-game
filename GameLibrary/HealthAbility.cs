using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public sealed class HealthAbility : Ability
    {
        public int Boost { get; set; }

        public override string ToString()
        {
            return $"Heal {Boost} Health!";
        }
        public override void Use(Fighter player, Fighter enemy)
        {
            if (player.MaxHealth + Boost > player.MaxHealth)
            {
                player.Health = player.MaxHealth;
            }
            else
            {
                player.Health += Boost;
            }
        }
    }
}
