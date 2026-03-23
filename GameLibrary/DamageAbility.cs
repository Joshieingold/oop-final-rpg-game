using Core.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public sealed class DamageAbility : Ability
    {
        public int Damage { get; set; }
        List<ProgLang> StrongAgainst { get; set; } 

        public override string ToString()
        {
            return $"{Name}: Use this to deal {Damage}!";
        }
        public override void Use(Fighter enemy)
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
                        enemy.Health -= Damage * 2;
                    }
                }
                enemy.Health -= Damage;
            }
        }
    }
}
