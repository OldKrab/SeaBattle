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

    [TestMethod]
    public void SwitchPlayers()
    {
        Game game = new Game();
        var prevCurrentplayer = game.CurrentPlayer;
        var prevOtherPlayer = game.OtherPlayer;
        game.SwitchPlayers();
        Assert.AreSame(prevCurrentplayer, game.OtherPlayer);
        Assert.AreSame(prevOtherPlayer, game.CurrentPlayer);
    }
}