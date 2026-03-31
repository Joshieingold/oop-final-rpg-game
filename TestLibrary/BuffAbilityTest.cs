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
    //we'll come back to this

    /*[TestMethod]
    public void Use_MaxHealth()
    {
        //arrange
        Fighter player;
        Fighter enemy;
        BuffAbility buffAb = new BuffAbility();
        buffAb.Buff = 30;
        buffAb.TargetStat = "MaxHealth";
        
        //act
        int expected = player.MaxHealth += buffAb.Buff;

        //assert
    }
    */
}
