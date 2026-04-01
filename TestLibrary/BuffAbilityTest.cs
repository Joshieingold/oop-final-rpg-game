using Core.Entities;
using Core.ItemsAndAbilities;

namespace BuffAbilities;

[TestClass]
public class BuffAbilityTest
{
    [TestMethod]
    public void Buff_ToString()
    {
        //arrange
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 20;
        buffAb.TargetStat = "heroJuice";

        //act
        string expected = "Permenantly gain 20 heroJuice";
        string actual = buffAb.ToString();

        //assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Use_MaxHealth()
    {
        //arrange
        Fighter player;
        Fighter enemy;
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 30; // we add 30 to it so it should be 50;
        buffAb.TargetStat = "MaxHealth";

        //act
        buffAb.Use(p1, p2);

        int actual = p1.MaxHealth; // Check what we got after using it
        int expected = 50; // should be 50

        //assert
        Assert.AreEqual(expected, actual);
    }
}
