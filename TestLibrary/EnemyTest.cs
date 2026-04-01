using Core.Entities;
using Core.ItemsAndAbilities;

namespace EnemyTest
{
    [TestClass]
    public class EnemyTest 
    {
        [TestMethod]
        public void Enemy_InitializedAbilitiesCount()
        {
            // Abilities should be initialized at 4
            Enemy e = new Enemy();
            int expectedAbilitiesCount = 4;
            Assert.AreEqual(expectedAbilitiesCount, e.Abilities.Count());
        }

        [TestMethod]
        public void Enemy_AbilitiesAreIAbilities()
        {
            // Abilities should be initialized as IAbilities
            Enemy e = new Enemy();
            bool expected = true;
            bool foundAbilities = true;
            foreach(Object ability in e.Abilities)
            {
                if (ability is IAbility a)
                {
                    continue;
                }
                else
                {
                    foundAbilities = false;
                    break;
                }

            }
            Assert.AreEqual(expected, foundAbilities);
        }
        [TestMethod]
        public void Enemy_ProgLangSpriteStringUpdated()
        {
            Enemy e = new Enemy();
            e.ErrorType = Core.State.ProgLang.Javascript;
            string result = e.EnemySprite;
            string expected = "/CreatureArt/scriptbeard.png";

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Enemy_MaxMovesCreatesSameAmountOfAbilities()
        {
            Enemy e = new Enemy();
            e.MaxMoves = 10;
            int result = e.Abilities.Count();
            int expected = 10;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Enemy_RandomAbilityGetsWithinResultSet()
        {
            Enemy e = new Enemy();


            bool result = true;
            for (int i = 0; i < e.MaxMoves; i++  )
            {
                if (!e.Abilities.Contains(e.ChooseRandomAbility())) {
                    result = false;
                    break;
                }
            }

            bool expected = true;

            Assert.AreEqual(expected, result);
        }

    }
}
