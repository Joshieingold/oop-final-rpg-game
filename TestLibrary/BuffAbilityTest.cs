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
    public void Use_MaxHealth_Test()
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
    public void Use_MaxHealth_NegativeValue_Test()
    {
        //arrange
        Player firstP = new Player("name");
        firstP.MaxHealth = -20;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 30;
        buffAb.TargetStat = "MaxHealth";

        //act & assert
        Assert.Throws<ArgumentException>(() => buffAb.Use(firstP, secondP));
    }
    [TestMethod]
    public void Use_MaxMana_Test()
    {
        //arrange
        Player firstP = new Player("name");
        firstP.MaxMana = 40;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 70;
        buffAb.TargetStat = "MaxMana";

        //act
        buffAb.Use(firstP, secondP);

        int actual = firstP.MaxMana;
        int expected = 110;

        //assert
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Use_MaxMana_NegativeValue_Test()
    {
        //arrange
        Player firstP = new Player("name");
        firstP.MaxMana = -30;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 20;
        buffAb.TargetStat = "MaxMana";

        //act & assert
        Assert.Throws<ArgumentException>(() => buffAb.Use(firstP, secondP));
    }
}
