using Core.Abilities;
using Core.Characters;
using Core.Entities;
using GameData;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Core.Utils
{
    public static class ObjectFactory
    {
        public static Ability CreateAbility(string inName)
        {
            string path = DataPasser.AbilityLocation();
            using (StreamReader stream = new StreamReader(path))
            {
                string currentLine;
                while ((currentLine = stream.ReadLine()) != null)
                {
                    string[] lineArray = currentLine.Split(" | ");
                    if (lineArray[0] == inName)
                    {
                        string name = lineArray[0];
                        int power = Convert.ToInt32(lineArray[1]);
                        int manaCost = Convert.ToInt32(lineArray[2]);
                        
                        List<ProgLang> strongAgainst = new List<ProgLang>();
                        string[] strStrongAgainstList = lineArray[3].Split(", ");
                        for (int i = 0; i < strStrongAgainstList.Length; i++)
                        {
                            string strLang = strStrongAgainstList[i].Trim();
                            ProgLang lang = (ProgLang)Enum.Parse(typeof(ProgLang), strLang);
                            if (lang != null)
                            {
                                strongAgainst.Add(lang);
                            }
                        }
                        // Early return so we dont always hit the worse case O(n)
                        return new Ability(name, power, manaCost, strongAgainst);
                    }
                }
                Console.WriteLine("No Data for that object found");
                return new Ability();
            }
        }
        // Creates a random Enemy from a programming langauge
        public static Enemy CreateEnemy(ProgLang inLang)
        {
            Random rand = new Random();

            string path = DataPasser.EnemyLocation();
            List<Enemy> allEnemies = new List<Enemy>();

            using (StreamReader stream = new StreamReader(path))
            {
                string currentLine;
                while ((currentLine = stream.ReadLine())!= null)
                {
                    string[] lineArray = currentLine.Split(" | ");
                    for (int i = 0; i < lineArray.Length; i++)
                    {
                        Console.WriteLine(lineArray[i]);
                    }
                    ProgLang lang = (ProgLang)Enum.Parse(typeof(ProgLang), lineArray[4]);
                    if (lang == inLang)
                    {
                        string enemyName = lineArray[0];
                        int enemyHealth = Convert.ToInt32(lineArray[1]);
                        int enemyAttack = Convert.ToInt32(lineArray[2]);
                        int enemyDefense = Convert.ToInt32(lineArray[3]);

                        Enemy thisEnemy = new Enemy();
                        thisEnemy.Name = enemyName;
                        thisEnemy.MaxHealth = enemyHealth;
                        thisEnemy.Health = enemyHealth;
                        thisEnemy.Attack = enemyHealth;
                        thisEnemy.Defense = enemyDefense;
                        thisEnemy.LanguageType = lang;
                        allEnemies.Add(thisEnemy);
                    }
                }
            }
            int randomIndex = rand.Next(0, allEnemies.Count());
            return allEnemies[randomIndex];
        }
        // Creates a Specific Enemy from their name 
        public static Player CreatePlayer(string inName)
        {
            return new Player(inName);
        }

    }
}
