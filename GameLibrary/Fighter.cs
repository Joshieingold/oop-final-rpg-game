using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class Fighter
    {
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int MaxMana { get; set; }
        public int Mana { get; set; }
        public List<IAbility> Abilities { get; set; }
        public void UseAbility()
        {
            return;
        }
    }
}
