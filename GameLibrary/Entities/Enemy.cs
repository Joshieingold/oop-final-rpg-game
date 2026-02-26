using Core.Abilities;
using Core.Characters;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    // FIX:
    // Abilities should be based on the Created enemies language
    public class Enemy : Entity
    {
        private const int NUM_MOVES = 4;
        public ProgLang LanguageType { get; set; }
        public List<Ability> Abilities { get; set; } 
        private Random enemyAttackRandomizer = new Random();
        public Enemy() // Defaults to JS
        {
            Abilities = GetMoveSet(ProgLang.Javascript);
        }
        public Enemy(ProgLang inLang) // Defaults to JS
        {
            Abilities = GetMoveSet(inLang);
        }
        // For Attacking
        public void UseAttack(Entity defender)
        {
            int attackVal = ChooseRandomAbility().Power + Attack;
            int damage = attackVal - defender.Defense;

            // Deal the damage
            if (damage < 0) damage = 0;
            defender.Health -= damage;
        }
        // For Giving ability on victory
        public Ability RequestAbility()
        {
            int choice = enemyAttackRandomizer.Next(0, (Abilities.Count()));
            return Abilities[choice];
        }
        public override string ToString()
        {
            return $"{Name}\nProgramming Language: {LanguageType}\nHP: {Health}\nAtk: {Attack}\nDef: {Defense}";
        }
        private Ability ChooseRandomAbility()
        {
            int choice = enemyAttackRandomizer.Next(0, Abilities.Count());
            return Abilities[choice];
        }
        private List<Ability> GetMoveSet(ProgLang inLang)
        {
            List<Ability> returnList = new List<Ability>();
            for (int i = 0; i < NUM_MOVES; i++)
            {
                returnList.Add(ObjectFactory.CreateAbilityByLang(inLang));
            }
            return returnList;
        }
    }
}
