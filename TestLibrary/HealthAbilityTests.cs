using Core.ItemsAndAbilities;

namespace HealthAbilities;

[TestClass]
public class HealthAbilityTests
{
    [TestMethod]
    public void Health_ToString()
    {
        //arrange
        HealthAbility health = new HealthAbility();
        health.Boost = 85;

        //act
        string expected = "Heal 85 Health!";
            string actual = health.ToString();

        //assert
        Assert.AreEqual(expected, actual);
    }
}
