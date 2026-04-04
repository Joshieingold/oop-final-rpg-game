using Core;
using Core.Entities;
using Core.ItemsAndAbilities;
using Core.State;
using GameData;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Core.Factories
{
    public class EnemyFactory
    {
        private Random rand = new Random();
        public List<Enemy> RequestXNewEnemies(int amount)
        {
            List<Enemy> rList = new List<Enemy>();
            for (int i = 0; i < amount; i++)
            {
                rList.Add(RequestRandomEnemy(i+1));
            }
            return rList;
        }
        public Enemy RequestRandomEnemy(int roundNumber)
        {

            Enemy rEnemy = new Enemy();
            try
            {
                rEnemy.MaxMoves = 4 + roundNumber;
                rEnemy.ErrorType = GetEnemyProgLang();
                rEnemy.Name = GetEnemyName(rEnemy.ErrorType);
                rEnemy.Attack = rEnemy.Attack * rand.Next(1, roundNumber);
                rEnemy.Defense = rEnemy.Defense * rand.Next(1, roundNumber);
                rEnemy.MaxHealth = rEnemy.MaxHealth * rand.Next(1, roundNumber);
                rEnemy.MaxMana = rEnemy.MaxMana * rand.Next(1, roundNumber);
                rEnemy.Health = rEnemy.MaxHealth;
                rEnemy.Mana = rEnemy.MaxMana;
                rEnemy.Abilities = GetAbilitiesByLang(rEnemy.ErrorType, rEnemy.MaxMoves);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rEnemy;
        }
        private List<IAbility> GetAbilitiesByLang(ProgLang lang, int numAbilities) // THIS DOES NOT CURRENTLY CARE ABOUT LANG CAUSE NO SUCH THING EXISTS
        {
            return new AbilityFactory().GetXNewAbilities(numAbilities);
        }
        private ProgLang GetEnemyProgLang()
        {
            string[] allLangs = Enum.GetNames(typeof(ProgLang));
            int maxIndex = allLangs.Length;
            try
            {
                return Enum.Parse<ProgLang>(allLangs[rand.Next(maxIndex)]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error parsing Enemy Programming Language\n{ex.Message}");
                return ProgLang.Javascript;
            }
        }
        private string GetErrorTypeFromProgLang(ProgLang lang)
        {
            switch(lang)
            {
                case ProgLang.Javascript:
                    return "Javascript";
                case ProgLang.Cs:
                    return "C#";
                case ProgLang.C:
                    return "C";
                case ProgLang.Java:
                    return "Java";
                case ProgLang.Cpp:
                    return "C++";
                case ProgLang.Python:
                    return "Python";
                case ProgLang.Bash:
                    return "Bash";
                default:
                    throw new ArgumentException();
            }

        }
        private string GetEnemyName(ProgLang lang)
        {
            string ErrorStringName = GetErrorTypeFromProgLang(lang);
            string[] names = File.ReadAllLines(DataPasser.EntityDataLocation("EnemyNames.txt"));
            int maxIndex = names.Length;
            return lang + names[rand.Next(maxIndex)];
        }
    }
}
