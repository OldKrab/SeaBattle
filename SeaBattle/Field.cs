using System.Drawing;

namespace SeaBattle;

public enum Orientation
{
    Vertical, Horizontal
}


public class Field
{
    public List<Ship> Ships { get; set; }
    public int CellsHeight => _shipParts.GetLength(0);
    public int CellsWidth => _shipParts.GetLength(1);

    public static int DefaultSize = 10;

    public Field()
    {
        _shipParts = new ShipPart[DefaultSize, DefaultSize];
        Ships = new List<Ship>();
    }

    public void AddShip(Ship ship, Point position, Orientation orientation)
    {
        Ships.Add(ship);
        for (int i = 0; i < ship.Size; i++)
        {
            CheckAndSetCell(position, ship.Parts[i]);
            if (orientation == Orientation.Horizontal)
                position.X++;
            else
                position.Y++;
        }
    }

    public ShipPart GetShipPart(Point shipPoint)
    {
        return _shipParts[shipPoint.Y, shipPoint.X];
    }

    public void Shoot(Point point)
    {
        GetShipPart(point)?.Kill();
    }


    private void CheckAndSetCell(Point shipPoint, ShipPart part)
    {
        if (IsOverlapping(shipPoint, part))
            throw new ShipOverlappingException(shipPoint);
        SetShip(shipPoint, part);
    }

    private void SetShip(Point shipPoint, ShipPart part)
    {
        _shipParts[shipPoint.Y, shipPoint.X] = part;
    }

    private bool IsOverlapping(Point p, ShipPart part)
    {
        for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
                if (p.X + i >= 0 && p.X + i < CellsWidth && p.Y + j >= 0 && p.X + i < CellsHeight)
                {
                    var ship = GetShipPart(new Point(p.X + i, p.Y + j));
                    if (ship != null && ship.Ship != part.Ship)
                        return true;
                }

        return false;
    }

    private ShipPart[,] _shipParts { get; set; }
}