using System;
using System.Collections.Generic;
using System.Text;

namespace GameData
{
    public static class DataPasser
    {
        public static string AbilityLocation()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ObjectData", "Ability.txt");
        }
        public static string EnemyLocation()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ObjectData", "Enemy.txt");
        }
        public static string EntityDataLocation(string specificFile)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ObjectData/", specificFile);
        }
        public static string PictureLocation()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
        }
    }
}
