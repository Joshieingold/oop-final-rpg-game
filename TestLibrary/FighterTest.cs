using Core.Entities;
using Core.Items;

namespace FighterTest;

[TestClass]
public class FighterTest
{
    [TestMethod]
    public void Fighter_NotEnoughMana()
    {
        Player play = new Player("Test");
        DamageAbility abil = new DamageAbility();
        play.Abilities.Add(abil);
        abil.ManaCost = 20;
        play.Mana = 15;

        bool actual = play.ValidateAbility(abil);
        bool expected = false;

        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Fighter_ExactlyEnoughMana()
    {
        Player play = new Player("Test");
        DamageAbility abil = new DamageAbility();
        abil.ManaCost = 20;
        play.Abilities.Add(abil);
        play.Mana = 20;

        bool actual = play.ValidateAbility(abil);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Fighter_EnoughMana()
    {
        Player play = new Player("Test");
        DamageAbility abil = new DamageAbility();
        play.Abilities.Add(abil);
        abil.ManaCost = 20;
        play.Mana = 40;

        bool actual = play.ValidateAbility(abil);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Fighter_UsingUnownedAbility()
    {
        Player play = new Player("Test");
        DamageAbility abil = new DamageAbility();
        abil.ManaCost = 20;
        play.Mana = 40;

        bool actual = play.ValidateAbility(abil);
        bool expected = false;

        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Fighter_UsingOwnedAbility()
    {
        Player play = new Player("Test");
        DamageAbility abil = new DamageAbility();
        play.Abilities.Add(abil);
        abil.ManaCost = 20;
        play.Mana = 40;

        bool actual = play.ValidateAbility(abil);
        bool expected = true;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Fighter_HealthNegativeValue()
    {
        Player play = new Player("Test");
        play.Health = -12; 

        int actual = play.Health;
        int expected = 0;

        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Fighter_HealthPositiveValue()
    {
        Player play = new Player("Test");
        play.Health = 12; 

        int actual = play.Health;
        int expected = 12;

        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Fighter_HealthMoreThanMaxValue()
    {
        Player play = new Player("Test");
        play.MaxHealth = 10;
        play.Health = 12;

        int actual = play.Health;
        int expected = 10;

        Assert.AreEqual(expected, actual);
    }
    //
    [TestMethod]
    public void Fighter_ManaNegativeValue()
    {
        Player play = new Player("Test");
        play.Mana = -12; 

        int actual = play.Mana;
        int expected = 0;

        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Fighter_ManaPositiveValue()
    {
        Player play = new Player("Test");
        play.Mana = 12; 

        int actual = play.Mana;
        int expected = 12;

        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Fighter_ManaMoreThanMaxValue()
    {
        Player play = new Player("Test");
        play.MaxMana = 10;
        play.Mana = 12;

        int actual = play.Health;
        int expected = 10;

        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Fighter_AttackNegativeValue()
    {
        Player play = new Player("Test");
        play.Attack = -20;

        int actual = play.Attack;
        int expected = 0;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Fighter_AttackPositiveValue()
    {
        Player play = new Player("Test");
        play.Attack = 20;

        int actual = play.Attack;
        int expected = 20;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Fighter_DefenseNegativeValue()
    {
        Player play = new Player("Test");
        play.Defense = -20;

        int actual = play.Defense;
        int expected = 0;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Fighter_DefensePositiveValue()
    {
        Player play = new Player("Test");
        play.Defense = 20;

        int actual = play.Defense;
        int expected = 20;

        Assert.AreEqual(expected, actual);
    }
}
