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
        public override void Use(Fighter attacker, Fighter defender) // Heals a character and ensures their health doesnt exceed maximum.
        {
            if (attacker.Health + Boost > attacker.MaxHealth)
            {
                attacker.Health = attacker.MaxHealth;
            }
            else
            {
                attacker.Health += Boost;
            }
            attacker.Mana -= ManaCost;
        }
        public void Use(Fighter attacker) // overload because defender is not affected
        {
            if (attacker.Health + Boost > attacker.MaxHealth)
            {
                attacker.Health = attacker.MaxHealth;
            }
            else
            {
                attacker.Health += Boost;
            }
            attacker.Mana -= ManaCost;
        }
    }
}
