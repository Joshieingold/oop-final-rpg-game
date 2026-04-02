using Core.Entities;
using Core.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Items
{
    public sealed class DamageAbility : Ability
    {
        public int Damage { get; set; }
        public List<ProgLang> StrongAgainst { get; set; }

        public override string ToString()
        {
            return $"Deal {Damage} Damage!";
        }
        public override void Use(Fighter attacker, Fighter enemy)
        {
            if (enemy.Health - Damage < 0)
            {
                enemy.Health = 0;
            }
            else
            {
                if (enemy is Enemy e)
                {
                    if (StrongAgainst.Contains(e.ErrorType))
                    {
                        int foundDamage = ((attacker.Attack + Damage * 2) - enemy.Defense);
                        if (foundDamage < 0) return;
                        enemy.Health -= foundDamage;
                        return;
                    }
                }
                int otherdmg = ((attacker.Attack + Damage) - enemy.Defense);
                
                attacker.Mana -= ManaCost;
                if (otherdmg < 0) return;
                enemy.Health -= otherdmg;
                return;
            }
        }
    }
}
