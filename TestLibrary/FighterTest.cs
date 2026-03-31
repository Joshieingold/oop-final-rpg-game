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

}
