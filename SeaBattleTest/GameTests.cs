using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle;

namespace SeaBattleTest;

[TestClass]
public class GameTests
{
    [TestMethod]
    public void Init()
    {
        Game game = new Game();
        Assert.IsNotNull(game.CurrentPlayer);
        Assert.IsNotNull(game.OtherPlayer);
    }
}