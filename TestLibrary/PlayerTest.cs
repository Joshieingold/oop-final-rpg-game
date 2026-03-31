using Core.Entities;

namespace Players;

[TestClass]
public class PlayerTest
{
    [TestMethod]
    public void Player_GenderChangesSpriteCaseFemale()
    {
        Player p = new Player("name");
        p.IsMale = false;

        string expected = "/ProtagonistSprites/vimmi.png";
        string actual = p.PlayerSprite;

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Player_GenderChangesSpriteCaseMale()
    {
        Player p = new Player("name");
        p.IsMale = true;

        string expected = "/ProtagonistSprites/nanon.png";
        string actual = p.PlayerSprite;

        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Player_NoName()
    {
        Player p;
        Assert.Throws<InvalidDataException>(() => p = new Player(""));
    }
    [TestMethod]
    public void Player_ValidName()
    {
        Player p = new Player("Test");
        string actual = p.Name;
        string expected = "Test";

        Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Player_CannotAfford()
    {
        Player p = new Player("Test");
        p.Money = 2;

        bool actual = p.CheckCanAfford(50);
        bool expected = false;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Player_CanExactlyAfford()
    {
        Player p = new Player("Test");
        p.Money = 50;

        bool actual = p.CheckCanAfford(50);
        bool expected = true;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Player_CanEasilyAfford()
    {
        Player p = new Player("Test");
        p.Money = 50;

        bool actual = p.CheckCanAfford(20);
        bool expected = true;
        Assert.AreEqual(expected, actual);
    }
}
