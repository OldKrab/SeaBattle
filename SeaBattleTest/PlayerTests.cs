using System.Drawing;
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

    [TestMethod]
    public void HasAliveShips()
    {
        Player player = new Player();
        player.Field.AddShip(new Ship(1), new Point(1,1), Orientation.Horizontal);
        Assert.IsTrue(player.HasAliveShips());
    }

    [TestMethod]
    public void DoesNotHaveAliveShipsWithZeroShips()
    {
        Player player = new Player();
        Assert.IsFalse(player.HasAliveShips());
    }

    [TestMethod]
    public void DoesNotHaveAliveShipsAfterKill()
    {
        Player player = new Player();
        player.Field.AddShip(new Ship(1), new Point(1,1), Orientation.Horizontal);
        player.Field.Shoot(new Point(1,1));
        Assert.IsFalse(player.HasAliveShips());
    }

    [TestMethod]
    public void HasAliveShipsWith2ShipsAfterOneKill()
    {
        Player player = new Player();
        player.Field.AddShip(new Ship(1), new Point(1,1), Orientation.Horizontal);
        player.Field.AddShip(new Ship(1), new Point(2,2), Orientation.Horizontal);
        player.Field.Shoot(new Point(1,1));
        Assert.IsTrue(player.HasAliveShips());
    }
}