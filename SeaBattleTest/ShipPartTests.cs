using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle;

namespace SeaBattleTest;

[TestClass]
public class ShipPartTests
{
    
    [TestMethod]
    public void Init()
    {
        Ship ship = new Ship(1);
        var shipPart = ship.Parts.First();
        Assert.IsNotNull(shipPart);
        Assert.AreSame(shipPart.Ship, ship);
        Assert.IsTrue(shipPart.IsAlive);
    }
}