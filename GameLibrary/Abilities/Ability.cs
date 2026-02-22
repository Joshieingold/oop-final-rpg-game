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
        public override string ToString()
        {
            return $"{Name}: !{Power} - %{ManaCost}";
        }
    }
}
