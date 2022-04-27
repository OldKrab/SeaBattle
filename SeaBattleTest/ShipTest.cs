using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle;

namespace SeaBattleTest;

[TestClass]
public class ShipTest
{
    [TestMethod]
    public void InitWith3()
    {
        Ship ship = new Ship(3);
        Assert.AreEqual(ship.Size, 3);
        Assert.AreEqual(ship.Parts.Length, 3);
        CollectionAssert.AllItemsAreNotNull(ship.Parts);
    }
}