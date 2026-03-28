using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    // I dont think this can be sealed and I will need to make further classses from this one specifically
    public class BuffAbility : Ability
    {
        public int Buff { get; set; }
        public string TargetStat { get; set; }

        public override string ToString()
        {
            return $"Permenantly gain {Buff} {TargetStat}";
        }
        // Use case for an enum if ive ever seen one
        public override void Use(Fighter player, Fighter enemy)
        {
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
        }
    }
}
