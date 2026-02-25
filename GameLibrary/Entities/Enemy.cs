using Core.Abilities;
using Core.Characters;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Enemy : Entity
    {
        public ProgLang LanguageType { get; set; }
        public List<Ability> Abilities { get; set; } 
        private Random enemyAttackRandomizer = new Random();
        public Enemy()
        {
            Abilities = GetFourAbilities();
        }
        private Ability ChooseRandomAbility()
        {
            int choice = enemyAttackRandomizer.Next(0, Abilities.Count());
            return Abilities[choice];
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
        public void UseAttack(Entity loser)
        {
            // Check to see if we have that ability

            int attackVal = ChooseRandomAbility().Power + Attack;
            int damage = attackVal - loser.Defense;

            // Deal the damage
            if (damage < 0) damage = 0;
            loser.Health -= damage;
        }
        public Ability RequestAbility()
        {
            int choice = enemyAttackRandomizer.Next(1, Abilities.Count());
            return Abilities[choice];
        }
        public override string ToString()
        {
            return $"{Name}\nProgramming Language: {LanguageType}\nHP: {Health}\nAtk: {Attack}\nDef: {Defense}";
        }
        // Make random Assortment of enemy abilities
    }
}
