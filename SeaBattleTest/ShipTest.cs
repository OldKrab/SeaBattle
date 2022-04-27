using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle;

namespace SeaBattleTest;

[TestClass]
public class ShipTest
{

    private void InitWith(int n)
    {
        Ship ship = new Ship(n);
        Assert.AreEqual(ship.Size, n);
        Assert.AreEqual(ship.Parts.Length, n);
        CollectionAssert.AllItemsAreNotNull(ship.Parts);
    }

    [TestMethod]
    public void InitWith3() => InitWith(3);

    [TestMethod]
    public void InitWith0() => InitWith(0);



}