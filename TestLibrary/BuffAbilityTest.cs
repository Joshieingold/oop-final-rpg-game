using Core.Entities;
using Core.ItemsAndAbilities;
using System.Diagnostics.CodeAnalysis;

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
        p1.MaxHealth = 20;
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
        // firstP.MaxHealth = -20;  Well obviously the player shouldnt have negative health. But we could test what happens if the buff was -20
        firstP.MaxHealth = 20;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = -30;
        buffAb.TargetStat = "MaxHealth";
        buffAb.Use(firstP, secondP);

        int expected = 20;
        int actual = firstP.MaxHealth;

        //act && assert
        Assert.AreEqual(expected, actual);
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
        firstP.MaxMana = 30;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = -20;
        buffAb.TargetStat = "MaxMana";
        buffAb.Use(firstP, secondP);

        int actual = firstP.MaxMana;
        int expected = 30;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Use_AttackBoost_Test()
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
        firstP.Attack = 10;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = -5;
        buffAb.TargetStat = "Attack";
        buffAb.Use(firstP, secondP);

        int expected = 10;
        int actual = firstP.Attack;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Use_DefenseBuff_Test()
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
    public void Use_DefenseBuff_NegativeValue_Test()
    {
        //arrange
        Player firstP = new Player("name");
        firstP.Defense = 20;
        Player secondP = new Player("name");
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = -10;
        buffAb.TargetStat = "Defense";
        buffAb.Use(firstP, secondP);

        int expected = 20;
        int actual = firstP.Defense;

        Assert.AreEqual(expected, actual);
    }
}
