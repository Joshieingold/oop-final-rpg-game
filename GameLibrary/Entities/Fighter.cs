using Core.ItemsAndAbilities;

namespace Core.Entities
{
    public abstract class Fighter
    {
        /////////////////
        // Constructor //
        /////////////////
        public Fighter()
        {
            // Default Creation of a fighter.
            MaxHealth = 100; 
            MaxMana = 100;
            Defense = 30;
            Attack = 20;
            Health = MaxHealth;
            Mana = MaxMana;
        }

        ////////////
        // Fields //
        ////////////
        private int _maxHealth;
        private int _health;
        private int _maxMana;
        private int _mana;
        private int _defense;
        private int _attack;
        private string _name;

        ////////////////
        // Properties //
        ////////////////
        public int MaxHealth // MaxHealth can never be below 0.
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
        public int Health // Health can never be below 0 or above MaxHealth.
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
        public int MaxMana // MaxMana can never be below 0.

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
        public int Mana // Mana can never be below 0 or above MaxMana.
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
        public string Name // Name will be given a default if it is made with an empty string.
        {
            get { return _name; }
            set
            {
                if (value == "")
                { _name = "Unknown Programer"; }
                else { _name = value; }
            }
        }
        public int Attack // Attack can never be below 0.
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
        public int Defense // Defense can never be below 0.
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
        public List<IAbility> Abilities { get; set; } // List of abilities the fighter can use.


        /////////////
        // Methods //
        /////////////
        public void UseAbility(IAbility chosenAbility, Fighter target) // Uses an ability to attack another Fighter
        {
            chosenAbility.Use(this, target);
        }
        public bool ValidateAbility(IAbility chosenAbility) // Validates if an ability can be used.
        {
            // Ideally this would be private, however UI needs to be able to check first if it can be used.
            if (this.Mana - chosenAbility.GetManaCost() < 0) return false; // Not enough mana.
            if (!this.Abilities.Contains(chosenAbility)) return false; // Using an invalid ability somehow.
            return true;
        }
    }
}
