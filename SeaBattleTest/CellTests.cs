using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle;

namespace SeaBattleTest;

[TestClass]
public class CellTests
{
    [TestMethod]
    public void Init()
    {
        Cell cell = new Cell();
        Assert.IsFalse(cell.IsShooted);
        Assert.IsNull(cell.ShipPart);
    }

    [TestMethod]
    public void Shoot()
    {
        Cell cell = new Cell();
        Ship ship = new Ship(1);
        cell.ShipPart = ship.Parts.First();
        cell.Shoot();
        Assert.IsTrue(cell.IsShooted);
    }
}