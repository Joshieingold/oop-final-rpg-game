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
    }
}
