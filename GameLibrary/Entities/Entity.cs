using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Characters
{
    public abstract class Entity
    {
        private int _health;
        public string Name { get; set; }
        
        public int MaxHealth { get; set; }
        public int Health { get; set; } 
        public int Attack { get; set; }
        public int Defense { get; set; }
        private bool _isAlive;
        public bool IsAlive
        {
            get { return Health > 0; }
        }
    }
}
