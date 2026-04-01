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
        Player p1 = new Player("test");
        Player p2 = new Player("test");
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

        //act && assert
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

        //act && assert
        Assert.Throws<ArgumentException>(() => buffAb.Use(firstP, secondP));
    }

    [TestMethod]
    public void Use_Attack_Test()
    {
        //arrange
        Player firstP = new Player("name");
        firstP.Attack = 10;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 80;
        buffAb.TargetStat = "Attack";

        //act
        buffAb.Use(firstP, secondP);

        int actual = firstP.Attack;
        int expected = 90;

        //assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Use_Attack_NegativeValue_Test()
    {
        //arrange
        Player firstP = new Player("name");
        firstP.Attack = -200;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 50;
        buffAb.TargetStat = "Attack";

        //act && assert
        Assert.Throws<ArgumentException>(() => buffAb.Use(firstP, secondP));
    }
    [TestMethod]
    public void Use_Defense_Test()
    {
        //arrange
        Player firstP = new Player("name");
        firstP.Defense = 60;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 40;
        buffAb.TargetStat = "Defense";

        //act
        buffAb.Use(firstP, secondP);

        int actual = firstP.Defense;
            int expected = 100;

        //assert
        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Use_Defense_NegativeValue_Test()
    {
        //arrange
        Player firstP = new Player("name");
        firstP.Defense = -2;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 30;
        buffAb.TargetStat = "Defense";

        //act && assert
        Assert.Throws<ArgumentException>(() => buffAb.Use(firstP, secondP));
    }
}
