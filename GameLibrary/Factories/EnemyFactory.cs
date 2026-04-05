using Core.Entities;
using Core.State;
using GameData;

namespace Core.Factories
{
    public class EnemyFactory
    {
        
        //////////////////
        // Main Methods //
        //////////////////
        public List<Enemy> RequestXNewEnemies(int amount) // Returns a list of enemies in accordance with the amount requested
        {
            List<Enemy> rList = new List<Enemy>();
            for (int i = 0; i < amount; i++)
            {
                rList.Add(RequestRandomEnemy(i+1));
            }
            return rList;
        }
        public Enemy RequestRandomEnemy(int roundNumber) // creates a random Enemy.
        {
            Random rand = new Random();
            Enemy rEnemy = new Enemy();
            try
            {
                rEnemy.MaxMoves = rEnemy.MaxMoves + roundNumber;
                rEnemy.ErrorType = CreateEnemyProgLang();
                rEnemy.Name = CreateEnemyName(rEnemy.ErrorType);
                rEnemy.Attack = rEnemy.Attack * rand.Next(1, roundNumber);
                rEnemy.Defense = rEnemy.Defense * rand.Next(1, roundNumber);
                rEnemy.MaxHealth = rEnemy.MaxHealth * rand.Next(1, roundNumber);
                rEnemy.MaxMana = rEnemy.MaxMana * rand.Next(1, roundNumber);
                rEnemy.Health = rEnemy.MaxHealth;
                rEnemy.Mana = rEnemy.MaxMana;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rEnemy;
        }

        ////////////////////
        // Helper Methods //
        ////////////////////
        private ProgLang CreateEnemyProgLang() // Returns a random programming langauge for an enemy.
        {
            Random rand = new Random();
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
        private string GetErrorNameFromProgLang(ProgLang lang) // Gets the nice name of an enemy based on ProgLang.
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
        private string CreateEnemyName(ProgLang lang) // Creates an enemy name based on its language and txt file genration
        {
            Random rand = new Random();
            string ErrorStringName = GetErrorNameFromProgLang(lang);
            string[] names = File.ReadAllLines(DataPasser.EntityDataLocation("EnemyNames.txt"));
            int maxIndex = names.Length;
            // Gets random suffix from the file.
            return ErrorStringName + names[rand.Next(maxIndex)];
        }
    }
}
