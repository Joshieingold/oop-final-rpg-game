using Core.Entities;
using Core.ItemsAndAbilities;

namespace Core.Managers
{
    public class Fight
    {
        /////////////////
        // Constructor //
        /////////////////
        public Fight(Fighter inAttacker, Fighter inDefender, IAbility inAbility)
        {
            attacker = inAttacker;
            defender = inDefender;
            attacker.UseAbility(inAbility, defender);
        }

        ////////////////
        // Properties //
        ////////////////
        private Fighter attacker { get; set; }
        private Fighter defender { get; set; }

        /////////////
        // Methods //
        /////////////
        public List<Fighter> GetUpdatedFighters()
        {
            return new List<Fighter>() { attacker,defender};
        }
    }
}
