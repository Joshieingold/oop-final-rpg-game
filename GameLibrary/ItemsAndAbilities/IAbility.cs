using Core.Entities;

namespace Core.ItemsAndAbilities
{
    public interface IAbility : IShopItem
    {
        public int GetManaCost(); // retrieves the cost cost of the ability to cast. 
        public void Use(Fighter attacker, Fighter defender); // For how an enemy will use a skill against another.
    }
}
