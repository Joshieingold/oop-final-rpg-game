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
        public override void Use(Fighter player, Fighter enemy) // Implementation of how to use.
        {
            // The stat will be chosen based on this abilities target and will gain value based on it.
            if (TargetStat == "MaxHealth")
            {
                player.MaxHealth += Buff;
            }
            else if (TargetStat == "MaxMana")
            {
                player.MaxMana += Buff;
            }
            else if (TargetStat == "Attack")
            {
                player.Attack += Buff;
            }
            else if (TargetStat == "Defense")
            {
                player.Defense += Buff;
            }
            player.Mana -= ManaCost; // Always lose the mana if use could happen.
        }
    }
}
