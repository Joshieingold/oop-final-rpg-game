using Core.Items;
using Core.ItemsAndAbilities;
using Core.State;
using GameData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Factories
{
    public class AbilityFactory
    {
        private Random rand = new Random();
        public List<IAbility> GetXNewAbilities(int amount)
        {
            List<IAbility> rList = new List<IAbility>();
            for (int i = 0; i < amount; i++)
            {
                rList.Add(GetRandomAbility());
            }
            return rList;
        }
        public  IAbility GetRandomAbility()
        {
            Ability rAbility = DetermineAbilityType();
            rAbility.Name = GetRandomName(); // PROBABLY A PLACE HOLDER
            rAbility.ManaCost = GetRandomManaCost(); 
            rAbility.Price = GetRandomPrice(); 
            if (rAbility is BuffAbility ba)
            {
                ba.Buff = rand.Next(100);
                ba.TargetStat = GetTargetStat();
            }
            else if (rAbility is DamageAbility da)
            {
                da.Damage = rand.Next(100);
                da.StrongAgainst = new List<ProgLang>() { ProgLang.Cpp, ProgLang.Javascript, ProgLang.Cs, ProgLang.C, ProgLang.Java, ProgLang.Python, ProgLang.Bash };
            }
            else if (rAbility is HealthAbility ha)
            {
                ha.Boost = rand.Next(100);
            }
            return rAbility;
        }
        private string GetTargetStat()
        {
            string[] allStats = new string[] { "MaxHealth", "MaxMana", "Attack", "Defense"};
            return allStats[rand.Next(allStats.Length)];
        }
        private string GetRandomName()
        {
            string[] names = File.ReadAllLines(DataPasser.EntityDataLocation("AbilityNames.txt"));
            int maxIndex = names.Length;
            return names[rand.Next(maxIndex)];
        }
        private int GetRandomManaCost()
        {
            return rand.Next(20);
        }
        private int GetRandomPrice()
        {
            return rand.Next(10);
        }
        private Ability DetermineAbilityType()
        {
            int randomInt = rand.Next(3);
            switch (randomInt)
            {
                case 0:
                    return new DamageAbility();
                case 1:
                    return new BuffAbility();
                case 2:
                    return new HealthAbility();
                default:
                    Console.WriteLine("There was an error creating an ability");
                    return new DamageAbility();
            }
        }
    }
}
