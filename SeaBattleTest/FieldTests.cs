using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeaBattle;

namespace SeaBattleTest;

[TestClass]
public class FieldTests
{
    [TestMethod]
    public void Init()
    {
        Field field = new Field();
        Assert.IsNotNull(field.Ships);
        Assert.AreEqual(field.Ships.Count, 0);

        Assert.IsNotNull(field.Cells);
        Assert.AreEqual(field.Cells.GetLength(0), Field.DefaultSize);
        Assert.AreEqual(field.Cells.GetLength(1), Field.DefaultSize);
    }



    [TestMethod]
    public void AddShipWithSize1()
    {
        Field field = new Field();
        Ship ship = new Ship(1);
        Point position = new Point(1, 1);
        Orientation orientation = Orientation.Horizontal;
        Point[] shipPoints = { new(1, 1) };

        field.AddShip(ship, position, orientation);
        CheckShipAdded(shipPoints, ship, field);
    }

    [TestMethod]
    public void AddShipWithSize3Vertical()
    {
        Field field = new Field();
        Ship ship = new Ship(3);
        Point position = new Point(1, 1);
        Orientation orientation = Orientation.Vertical;
        Point[] shipPoints = { new(1, 1), new(1, 2), new(1, 3) };

        field.AddShip(ship, position, orientation);
        CheckShipAdded(shipPoints, ship, field);
    }

    [TestMethod]
    public void AddShipWithSize3Horizontal()
    {
        Field field = new Field();
        Ship ship = new Ship(3);
        Point position = new Point(1, 1);
        Orientation orientation = Orientation.Horizontal;
        Point[] shipPoints = { new(1, 1), new(2, 1), new(3, 1) };

        field.AddShip(ship, position, orientation);
        CheckShipAdded(shipPoints, ship, field);
    }

    
    [TestMethod]
    public void ShootMiss()
    {
        Field field = new Field();
        Ship ship = new Ship(3);

        field.AddShip(ship, new Point(1, 1), Orientation.Horizontal);

        field.Shoot(new Point(1, 2));
        Assert.IsTrue(ship.IsAlive());
    }

    [TestMethod]
    public void ShootHitAndKill()
    {
        Field field = new Field();
        Ship ship = new Ship(1);

        field.AddShip(ship, new Point(1, 1), Orientation.Horizontal);

        field.Shoot(new Point(1, 1));
        Assert.IsFalse(ship.IsAlive());
    }

    [TestMethod]
    public void ShootHitAndNotKill()
    {
        Field field = new Field();
        Ship ship = new Ship(3);

        field.AddShip(ship, new Point(1, 1), Orientation.Horizontal);

        field.Shoot(new Point(1, 1));
        Assert.IsTrue(ship.IsAlive());
    }


    private void CheckShipAdded(Point[] shipPoints, Ship ship, Field field)
    {
        Assert.AreSame(field.Ships.Last(), ship);

        foreach (var (shipPoint, shipPart) in shipPoints.Zip(ship.Parts))
        {
            Assert.IsNotNull(field.GetCell(shipPoint));
            Assert.AreSame(field.GetCell(shipPoint), shipPart);
        }

        for (int i = 0; i < field.Cells.GetLength(0); i++)
        for (int j = 0; j < field.Cells.GetLength(1); j++)
        {
            Point curPoint = new Point(i, j);
            if (shipPoints.All(p => !p.Equals(curPoint)))
                Assert.IsNull(field.GetCell(curPoint));
        }
    }
}