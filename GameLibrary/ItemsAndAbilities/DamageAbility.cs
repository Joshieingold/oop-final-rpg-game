using Core.Entities;
using Core.State;

namespace Core.Items
{
    public sealed class DamageAbility : Ability
    {
        ////////////
        // Fields //
        ////////////
        private int _damage;

        ////////////////
        // Properties //
        ////////////////
        public List<ProgLang> StrongAgainst { get; set; } // List of Programming lanaguges this ability is good against.
        public int Damage // Damage must be at least 1.
        {
            get { return _damage; }
            set
            {
                if (value < 1) _damage = 1;
                else _damage = value;
            }
        }

        /////////////
        // Methods //
        /////////////
        public override string ToString()
        {
            return $"Deal {Damage} Damage!";
        }
        public override void Use(Fighter attacker, Fighter defender) // Deals damage to a Figher and inflicts bonus on qualifying Enemies.
        {
            if (defender is Enemy e) // If its an enemy we need to check if it needs extra damage.
            {
                if (StrongAgainst.Contains(e.ErrorType)) // If this skill is good against this enemy apply bonus damage and leave early.
                {
                    int foundDamage = ((attacker.Attack + Damage * 2) - defender.Defense);
                    if (foundDamage < 0) return;
                    attacker.Mana -= ManaCost;
                    defender.Health -= foundDamage;
                    return;
                }
            }

            // Otherwise deal normal damage to player or enemy.
            int otherdmg = ((attacker.Attack + Damage) - defender.Defense);
            attacker.Mana -= ManaCost;
            if (otherdmg < 0) return;
            defender.Health -= otherdmg;
        }
    }
}
