using Core.Items;

namespace DamageAbilities;

[TestClass]
public class DamageAbilityTests
{
    [TestMethod]
    public void Damage_ToString()
    {
        //arrange
        DamageAbility dam = new DamageAbility();
        dam.Damage = 70;

        //act
        string expected = "Deal 70 Damage!";
            string actual = dam.ToString();

        //assert
        Assert.AreEqual(expected, actual);
    }
}
