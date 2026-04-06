using Core.Entities;
using Core.Items;

namespace Core.ItemsAndAbilities
{
    public sealed class BuffAbility : Ability
    {
        ////////////
        // Fields //
        ////////////
        private int _buff;

        ////////////////
        // Properties //
        ////////////////
        public string TargetStat { get; set; } // The stat this ability will add value to.
        public int Buff // cannot be less than 0.
        {
            get { return _buff; }
            set
            {
                if (value < 0)
                {
                    _buff = 0;
                }
                else
                {
                    _buff = value;
                }
            }

        }

        /////////////
        // Methods //
        /////////////
        public override string ToString()
        {
            return $"Permenantly gain {Buff} {TargetStat}";
        }
        public override void Use(Fighter attacker, Fighter defender) // Implementation of how to use. Needs to be accounted for.
        {
            // The stat will be chosen based on this abilities target and will gain value based on it.
            if (TargetStat == "MaxHealth")
            {
                attacker.MaxHealth += Buff;
            }
            else if (TargetStat == "MaxMana")
            {
                attacker.MaxMana += Buff;
            }
            else if (TargetStat == "Attack")
            {
                attacker.Attack += Buff;
            }
            else if (TargetStat == "Defense")
            {
                attacker.Defense += Buff;
            }
            attacker.Mana -= ManaCost; // Always lose the mana if use could happen.
        }
        public void Use(Fighter attacker) // Doesnt need defender reference
        {
            if (TargetStat == "MaxHealth")
            {
                attacker.MaxHealth += Buff;
            }
            else if (TargetStat == "MaxMana")
            {
                attacker.MaxMana += Buff;
            }
            else if (TargetStat == "Attack")
            {
                attacker.Attack += Buff;
            }
            else if (TargetStat == "Defense")
            {
                attacker.Defense += Buff;
            }
            attacker.Mana -= ManaCost; // Always lose the mana if use could happen.
        } 
    }
}
