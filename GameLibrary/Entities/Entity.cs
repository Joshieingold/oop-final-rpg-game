using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Characters
{
    public abstract class Entity : INotifyPropertyChanged
    {
        private int _health;
        public string Name { get; set; }
        
        public int MaxHealth { get; set; }
        public int Health {
            get { return _health; }
            set 
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public int Attack { get; set; }
        public int Defense { get; set; }
        private bool _isAlive;
        public bool IsAlive
        {
            get { return Health > 0; }
        }
    }
}
