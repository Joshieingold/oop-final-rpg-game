using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class Stats
    {
        private int _mana;
        private int _health;
        private int _magicDmg;
        private int _physicalDmg;
        public int MagicDamage { get { return _magicDmg; } set { _magicDmg = value; } }
        public int PhysicalDamage { get { return _physicalDmg; } set { _physicalDmg = value; } }
        public int Mana {
            get { return _mana; }
            set { if (value <= 0) { _mana = 0; } else { _mana = value; } }
        }
        public int Health 
        {
            get { return _health ; }
            set { if (value <= 0) { _health = 0; } else { _health = value; } }
        }
        public Stats(int inMana, int inHealth, int inMagicDmg, int inPhysicalDmg)
        {
            this.Mana = inMana; 
            this.Health = inHealth; 
            this.MagicDamage = inMagicDmg; 
            this.PhysicalDamage = inPhysicalDmg; 
        }
    }


}
