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

    [TestMethod]
    public void IsAliveAfterInitWith3()
    {
        Ship ship = new Ship(3);
        Assert.IsTrue(ship.IsAlive());
    }

    [TestMethod]
    public void IsDeadAfterInitWith0()
    {
        Ship ship = new Ship(0);
        Assert.IsFalse(ship.IsAlive());
    }

    [TestMethod]
    public void IsDeadAfterKillAllParts()
    {
        Ship ship = new Ship(3);
        foreach (var shipPart in ship.Parts)
            shipPart.Kill();
        Assert.IsFalse(ship.IsAlive());
    }

}