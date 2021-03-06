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

        Assert.AreEqual(field.CellsHeight, Field.DefaultSize);
        Assert.AreEqual(field.CellsWidth, Field.DefaultSize);
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
        Ship ship = new Ship(1);

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
    public void ShootCell()
    {
        Field field = new Field();
        var p = new Point(1, 1);
        field.Shoot(p);
        Assert.IsTrue(field.GetCell(p).IsShooted);
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

    [TestMethod]
    public void AddShipOverlap()
    {
        Field field = new Field();

        field.AddShip(new Ship(3), new Point(1, 1), Orientation.Horizontal);
        var exception = Assert.ThrowsException<ShipOverlappingException>(() =>
            field.AddShip(new Ship(3), new Point(2, 0), Orientation.Vertical));
        Assert.AreEqual(exception.OverlapPoint, new Point(2, 0));
    }

    [TestMethod]
    public void AddShipTouchBorders()
    {
        Field field = new Field();
        field.AddShip(new Ship(3), new Point(1, 1), Orientation.Horizontal);
        var exception = Assert.ThrowsException<ShipOverlappingException>(() =>
            field.AddShip(new Ship(1), new Point(0, 1), Orientation.Horizontal));
        Assert.AreEqual(exception.OverlapPoint, new Point(0, 1));

    }

    [TestMethod]
    public void AddShipTouchCorners()
    {
        Field field = new Field();
        field.AddShip(new Ship(3), new Point(1, 1), Orientation.Horizontal);
        var exception = Assert.ThrowsException<ShipOverlappingException>(() =>
             field.AddShip(new Ship(1), new Point(0, 0), Orientation.Horizontal));
        Assert.AreEqual(exception.OverlapPoint, new Point(0, 0));
    }



    private void CheckShipAdded(Point[] shipPoints, Ship ship, Field field)
    {
        Assert.AreSame(field.Ships.Last(), ship);

        foreach (var (shipPoint, shipPart) in shipPoints.Zip(ship.Parts))
        {
            Assert.IsNotNull(field.GetCell(shipPoint).ShipPart);
            Assert.AreSame(field.GetCell(shipPoint).ShipPart, shipPart);
        }

        for (int i = 0; i < field.CellsWidth; i++)
            for (int j = 0; j < field.CellsHeight; j++)
            {
                Point curPoint = new Point(i, j);
                if (shipPoints.All(p => !p.Equals(curPoint)))
                    Assert.IsNull(field.GetCell(curPoint).ShipPart);
            }
    }
}