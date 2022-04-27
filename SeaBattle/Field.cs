using System.Drawing;

namespace SeaBattle;

public enum Orientation
{
    Vertical, Horizontal
}


public class Field
{
    public List<Ship> Ships { get; set; }
    public int CellsHeight => _cells.GetLength(0);
    public int CellsWidth => _cells.GetLength(1);

    public static int DefaultSize = 10;

    public Field()
    {
        _cells = new ShipPart[DefaultSize, DefaultSize];
        Ships = new List<Ship>();
    }

    public void AddShip(Ship ship, Point position, Orientation orientation)
    {
        Ships.Add(ship);
        for (int i = 0; i < ship.Size; i++)
        {
            SetCell(position, ship.Parts[i]);
            if (orientation == Orientation.Horizontal)
                position.X++;
            else
                position.Y++;
        }
    }

    public ShipPart GetCell(Point shipPoint)
    {
        return _cells[shipPoint.Y, shipPoint.X];
    }

    public void Shoot(Point point)
    {
        GetCell(point)?.Kill();
    }


    private void SetCell(Point shipPoint, ShipPart part)
    {
        _cells[shipPoint.Y, shipPoint.X] = part;
    }

    private ShipPart[,] _cells { get; set; }
}