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
                string currentLine = stream.ReadLine();
                while (currentLine != null)
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
        public static Enemy CreateEnemy(string inName, ProgLang inLang)
        {
            return new Enemy(inName, inLang);
        }
        public static Player CreatePlayer(string inName)
        {
            return new Player(inName);
        }

    }
}
