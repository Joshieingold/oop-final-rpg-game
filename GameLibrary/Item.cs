using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GameLibrary
{
    public class Item
    {
        public Item() { }   // REQUIRED for deserialization

        public Item(string inName, string inDesc, string inDmgType, int inDmgVal)
        {
            Name = inName;
            Description = inDesc;
            DamageType = inDmgType;
            Damage = inDmgVal;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string DamageType { get; set; }
        public int Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Damage} {DamageType}): {Description}";
        }
    }
}
