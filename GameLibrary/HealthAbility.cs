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
            return $"{Name}: Use this to heal {Boost}!";
        }
        public override void Use(Fighter player)
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
