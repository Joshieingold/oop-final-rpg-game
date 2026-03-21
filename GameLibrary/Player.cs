using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public sealed class Player : Fighter
    {
        public int Money { get; set; }
        public Player(string inName)
        {
            Money = 5;
            Name = inName;
        }
    }
}
