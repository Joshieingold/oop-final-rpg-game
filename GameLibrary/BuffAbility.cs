using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    // I dont think this can be sealed and I will need to make further classses from this one specifically
    public class BuffAbility : Ability
    {
        private int Buff { get; set; }

        public override void Use()
        {
            return;
        }
    }
}
