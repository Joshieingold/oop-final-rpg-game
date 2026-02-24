using Core.Abilities;
using Core.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Enemy : Entity
    {
        public ProgLang LanguageType { get; set; }
        public List<Ability> Abilities { get; set; } = new(); // Make this based on the language type
        private Random enemyAttackRandomizer = new Random();
        public Enemy(string inName, ProgLang inLang)
        {
            Name = inName;
            LanguageType = inLang;


        }
        private Ability ChooseRandomAbility()
        {
            int choice = enemyAttackRandomizer.Next(1, Abilities.Count());
            return Abilities[choice];
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
            return $"{Name} is a {LanguageType.ToString()} Enemy with {Health}";
        }
    }
}
