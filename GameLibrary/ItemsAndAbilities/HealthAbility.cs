using Core.Entities;
using Core.Items;

namespace Core.ItemsAndAbilities
{
    public sealed class HealthAbility : Ability
    {
        ////////////////
        // Properties //
        ////////////////
        public int Boost { get; set; }

        /////////////
        // Methods //
        /////////////
        public override string ToString()
        {
            return $"Heal {Boost} Health!";
        }
        public override void Use(Fighter player, Fighter enemy) // Heals a character and ensures their health doesnt exceed maximum.
        {
            if (player.Health + Boost > player.MaxHealth)
            {
                player.Health = player.MaxHealth;
            }
            else
            {
                player.Health += Boost;
            }
            player.Mana -= ManaCost;
        }
    }
}
