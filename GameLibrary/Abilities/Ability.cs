using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abilities
{
    public class Ability
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int ManaCost { get; set; }
        public List<ProgLang> StrongAgainst { get; set; }
        public Ability()
        {
            Name = "Null";
            Power = 69;
            ManaCost = 67;
            StrongAgainst = new List<ProgLang>();
        }
        public Ability(string inName, int inPower, int inManaCost, List<ProgLang> inStrongAgainst )
        {
            Name = inName;
            Power = inPower;
            ManaCost = inManaCost;
            StrongAgainst = inStrongAgainst;
        }

        public override string ToString()
        {
            return $"{Name}: !{Power} - %{ManaCost}";
        }
    }
}
