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

    public void AddShip(Ship ship, Point position, Orientation orientation)
    {
        throw new NotImplementedException();
    }

    public ShipPart GetCell(Point shipPoint)
    {
        throw new NotImplementedException();
    }
}