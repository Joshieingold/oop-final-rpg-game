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
        Player firstP = new Player("name");
        firstP.MaxHealth = 20;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 30;
        buffAb.TargetStat = "MaxHealth";
        
        //act
        buffAb.Use(firstP, secondP);

        int actual = firstP.MaxHealth;
        int expected = 50;

        //assert
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Use_MaxHealth_Negative()
    {
        //arrange
        Player firstP = new Player("name");
        firstP.MaxHealth = -20;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 30;
        buffAb.TargetStat = "MaxHealth";

        //act
        buffAb.Use(firstP, secondP);

        int actual = firstP.MaxHealth;
        int expected = 10;

        //assert
        Assert.Throws<ArgumentException>(() => buffAb.Use(firstP, secondP));
    }
}
