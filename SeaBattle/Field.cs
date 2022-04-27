using System.Drawing;

namespace SeaBattle;

public enum Orientation
{
    Vertical, Horizontal
}


public class Field
{
    public List<Ship> Ships { get; set; }
    public ShipPart[,] Cells { get; set; }

    public static int DefaultSize = 10;

    public Field()
    {
        Cells = new ShipPart[DefaultSize, DefaultSize];
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
        return Cells[shipPoint.Y, shipPoint.X];
    }

    private void SetCell(Point shipPoint, ShipPart part)
    {
        Cells[shipPoint.Y, shipPoint.X] = part;
    }

    public void Shoot(Point point)
    {
        GetCell(point)?.Kill();
    }
}