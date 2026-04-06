using Core.Items;
using Core.ItemsAndAbilities;
using Core.State;
using GameData;

namespace Core.Factories
{
    public class AbilityFactory // Possibly a use case for static, but I dont need this loaded all the time. I think..
    {
        ///////////////
        // Constants //
        ///////////////
        private const int MAX_PRICE = 10;
        private const int MAX_MANA_COST = 20;
        private const int MAX_STAT_POWER = 100;
        
        //////////////////
        // Main Methods //
        //////////////////
        public List<IAbility> GetXNewAbilities(int amount) // Returns a list of abilities of the amount requested.
        {
            List<IAbility> rList = new List<IAbility>();
            for (int i = 0; i < amount; i++)
            {
                rList.Add(GetRandomAbility());
            }
            return rList;
        }
        private IAbility GetRandomAbility() // Generates one random ability
        {
            Random rand = new Random();
            Ability rAbility = DetermineAbilityType(); 
            rAbility.Name = GetRandomName(); 
            rAbility.ManaCost = GetRandomManaCost(); 
            rAbility.Price = GetRandomPrice();
            AddCustomPowers(rAbility);
            return rAbility;
        }

        ////////////////////
        // Helper Methods //
        ////////////////////
        private void AddCustomPowers(Ability inAbility)
        {
            Random rand = new Random();
            if (inAbility is BuffAbility ba)
            {
                ba.Buff = rand.Next(MAX_STAT_POWER);
                ba.TargetStat = GetTargetStat();
            }
            else if (inAbility is DamageAbility da)
            {
                da.Damage = rand.Next(MAX_STAT_POWER);
                da.StrongAgainst = new List<ProgLang>() { ProgLang.Cpp, ProgLang.Javascript, ProgLang.Cs, ProgLang.C, ProgLang.Java, ProgLang.Python, ProgLang.Bash };
            }
            else if (inAbility is HealthAbility ha)
            {
                ha.Boost = rand.Next(MAX_STAT_POWER);
            }
        }
        private string GetTargetStat() // Determines target stat for statboost abilities.
        {
            Random rand = new Random();
            string[] allStats = new string[] { "MaxHealth", "MaxMana", "Attack", "Defense"};
            return allStats[rand.Next(allStats.Length)];
        }
        private string GetRandomName() // Generates the name of an ability from text file.
        {
            Random rand = new Random();
            try
            {
                string[] names = File.ReadAllLines(DataPasser.EntityDataLocation("AbilityNames.txt")); // Try to retrieve it.
                int maxIndex = names.Length;
                return names[rand.Next(maxIndex)];
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException();
            }
        }
        private string GetRandomName(int fileIndex) // Allows choice of which name an item will have from the txt file // METHOD OVERLOAD
        {
            // If we got to it, this is how it would be easier to smooth over creating not random items with a JSON.
            try
            {
                string[] names = File.ReadAllLines(DataPasser.EntityDataLocation("AbilityNames.txt")); // Try to retrieve it.
                int maxIndex = names.Length;
                return names[fileIndex];
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException();
            }

        }
        private int GetRandomManaCost() // Creates Mana cost of an ability
        {
            Random rand = new Random();
            return rand.Next(MAX_MANA_COST);
        }
        private int GetRandomPrice() // Creates the cost of the ability.
        {
            Random rand = new Random();
            return rand.Next(MAX_PRICE);
        }
        private Ability DetermineAbilityType() // Creates A different derived class of Ability based on chance.
        {
            Random rand = new Random();
            int randomInt = rand.Next(3); // There are 3 types of abilities.
            switch (randomInt)
            {
                case 0:
                    return new DamageAbility();
                case 1:
                    return new BuffAbility();
                default:
                    return new HealthAbility();
            }
        }
    }
}
