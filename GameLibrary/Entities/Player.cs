using Core.Abilities;
using Core.Entities;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Characters
{
    // Abilities should be determined by the class that the user chooses at the beginning of the game IE prog analyst, web dev, etc
    public class Player : Entity
    {
        // Crit chances
        private const int NAT_20 = 20;
        private const int HIGH_ROLL = 16;
        // Crit chance multipliers
        private const double NATURAL_20_MULT = 5.0; 
        private const double HIGH_ROLL_MULT = 3.5;
        private const double NORMAL_ROLL_MULT = 1;
        private const double EFFECTIVE_HIT_MULT = 2;

        private const int NUM_MOVES = 4;
        private Random critChance = new Random();
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public List<Ability> Abilities { get; set; }
        public Player(string inName)
        {
            Name = inName;
            Mana = 100;
            MaxMana = 100;
            Health = 100;
            MaxHealth = Health;
            Attack = 22;
            Defense = 20;
            Abilities = GetStartingAbilities();
        }
        public override string ToString()
        {
            return $"{Name} has {Health} Health";
        }
        
        public void UseAttack(Ability inAbility, Entity defender)
        {
            // Check to see if we have that ability
            if (! Abilities.Contains(inAbility))
            {
                Console.WriteLine("You dont have that ability? How was this casted?!");
                return;
            }
            // Check to see if we have the mana for it
            if (Mana - inAbility.ManaCost < 0)
            {
                Console.WriteLine("You dont have the mana to cast that ability");
                return;
            }
            this.Mana -= inAbility.ManaCost;

            // Find values
            double crit = CheckCrit();
            double effective = CheckEffective(inAbility, defender);
            int attackVal = inAbility.Power + Attack;
            int defenderDefense = defender.Defense;

            // Deal the damage
            defender.Health -= FindDamage(crit, attackVal, effective, defenderDefense);
        }
        private List<Ability> GetStartingAbilities()
        {
            List<ProgLang> allLangs = Enum.GetValues(typeof(ProgLang)).Cast<ProgLang>().ToList();
            List<Ability> returnList = new List<Ability>();

            for (int i = 0; i < NUM_MOVES; i++)
            {
                int currentIndex = critChance.Next(0, allLangs.Count());
                ProgLang currentLang = allLangs[currentIndex];
                returnList.Add(ObjectFactory.CreateAbilityByLang(currentLang));
            }
            return returnList;
        }
        private double CheckEffective(Ability inAbility, Entity inEntity)
        {
            if (inEntity is Enemy inEnemy)
            {
            if (inAbility.StrongAgainst.Contains(inEnemy.LanguageType))
            {
                return EFFECTIVE_HIT_MULT;
            }
            return NORMAL_ROLL_MULT;
            }
            return NORMAL_ROLL_MULT;
        } 
        private int FindDamage(double crit, int attackVal, double effecitve, int defenderDefence)
        {
            int damage = Convert.ToInt32(((attackVal * crit) * effecitve) - defenderDefence);
            if (damage < 0) damage = 0;
            return damage;
        }
        private double CheckCrit() // returns the results values for our crit;
        {
            int diceRoll = critChance.Next(1, 20);
            if (diceRoll == NAT_20)
            {
                return NATURAL_20_MULT;
            }
            else if (diceRoll > HIGH_ROLL)
            {
                return HIGH_ROLL_MULT;
            }
            return NORMAL_ROLL_MULT;
        }
    }
}
