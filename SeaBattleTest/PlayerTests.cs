using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle;

namespace SeaBattleTest;

[TestClass]
public class PlayerTests
{
    [TestMethod]
    public void Init()
    {
        Player player = new Player();
        Assert.IsNotNull(player.Field);
    }
}