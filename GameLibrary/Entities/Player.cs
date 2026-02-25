using Core.Abilities;
using Core.Entities;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Characters
{
    public class Player : Entity
    {
        // Crit chances
        private const int NAT20 = 20;
        private const int HIGHROLL = 16;
        // Crit chance multipliers
        private const double NATURAL20MULT = 5.0; 
        private const double HIGHROLLMULT = 3.5;
        private const double NORMALROLLMULT = 1;

        private const double EFFECTIVEHITMULT = 2; 
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
            Abilities = GetFourAbilities();
        }
        public override string ToString()
        {
            return $"{Name} has {Health} Health";
        }
        
        public void UseAttack(Ability inAbility, Entity loser)
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
            double effective = CheckEffective(inAbility, loser);
            int attackVal = inAbility.Power + Attack;
            int defenderDefense = loser.Defense;

            // Deal the damage
            loser.Health -= FindDamage(crit, attackVal, effective, defenderDefense);
        }
        private List<Ability> GetFourAbilities()
        {
            List<Ability> returnList = new List<Ability>();
            returnList.Add(ObjectFactory.CreateAbility("ObjectOrientedProgramming"));
            returnList.Add(ObjectFactory.CreateAbility("SystemProgramming"));
            returnList.Add(ObjectFactory.CreateAbility("Performance"));
            returnList.Add(ObjectFactory.CreateAbility("DeveloperProductivity"));
            return returnList;
        }
        private double CheckEffective(Ability inAbility, Entity inEntity)
        {
            if (inEntity is Enemy inEnemy)
            {
            if (inAbility.StrongAgainst.Contains(inEnemy.LanguageType))
            {
                return EFFECTIVEHITMULT;
            }
            return NORMALROLLMULT;
            }
            return NORMALROLLMULT;
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
            if (diceRoll == NAT20)
            {
                return NATURAL20MULT;
            }
            else if (diceRoll > HIGHROLL)
            {
                return HIGHROLLMULT;
            }
            return NORMALROLLMULT;
        }
    }
}
