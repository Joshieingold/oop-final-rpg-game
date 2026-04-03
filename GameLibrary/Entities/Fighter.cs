using Core.Items;
using Core.ItemsAndAbilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public abstract class Fighter
    {
        private int _maxHealth;
        public int MaxHealth
        {
            get { return _maxHealth; }
            set
            {
                if (value < 0)
                {
                    _maxHealth = 0;
                }
                else
                {
                    _maxHealth = value;
                }
            }
        }
        private int _health;
        public int Health
        {
            get { return _health; }
            set
            {
                if (value < 0)
                {
                    _health = 0;
                }
                else if (value > MaxHealth)
                {
                    _health = MaxHealth;
                }
                else
                {
                    _health = value;
                }

            }
        }
        private int _maxMana;
        public int MaxMana
        {
            get { return _maxMana; }
            set
            {
                if (value < 0)
                {
                    _maxMana = 0;
                }
                else
                {
                    _maxMana = value;
                }

            }
        }
        private int _mana;
        public int Mana
        {
            get { return _mana; }
            set
            {
                if (value < 0)
                {
                    _mana = 0;
                }
                else if (value > MaxMana)
                {
                    _mana = MaxMana;
                }
                else
                {
                    _mana = value;
                }
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == "")
                { _name = "Unknown Programer"; }
                else { _name = value; }
            }
        }
        private int _attack;
        public int Attack
        {
            get { return _attack; }
            set
            {
                if (value < 0)
                {
                    _attack = 0;
                }
                else
                {
                    _attack = value;
                }
            }
        }
        private int _defense;
        public int Defense
        {
            get { return _defense; }
            set
            {
                if (value < 0)
                {
                    _defense = 0;
                }
                else
                {
                    _defense = value;
                }
            }
        }
        public List<IAbility> Abilities { get; set; }
        public Fighter()
        {
            MaxHealth = 100;
            MaxMana = 100;
            Defense = 40;
            Attack = 20;
            Health = MaxHealth;
            Mana = MaxMana;
        }
        public void UseAbility(IAbility chosenAbility, Fighter target)
        {
            chosenAbility.Use(this, target);
        }
        public bool ValidateAbility(IAbility chosenAbility)
        {
            if (this.Mana - chosenAbility.GetManaCost() < 0) return false; // Likely dont need to be using a method for this
            if (!this.Abilities.Contains(chosenAbility)) return false;
            return true;
        }
    }
}
