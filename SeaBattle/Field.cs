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
        _cells = new Cell[DefaultSize, DefaultSize];
        for (int i = 0; i < _cells.GetLength(0); i++)
            for (int j = 0; j < _cells.GetLength(1); j++)
                _cells[i, j] = new Cell();
        
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

    public void Shoot(Point point)
    {
        GetCell(point).ShipPart?.Kill();
    }


    private void CheckAndSetCell(Point shipPoint, ShipPart part)
    {
        if (IsOverlapping(shipPoint, part))
            throw new ShipOverlappingException(shipPoint);
        SetShip(shipPoint, part);
    }

    private void SetShip(Point shipPoint, ShipPart part)
    {
        _cells[shipPoint.Y, shipPoint.X].ShipPart = part;
    }

    private bool IsOverlapping(Point p, ShipPart part)
    {
        for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
                if (p.X + i >= 0 && p.X + i < CellsWidth && p.Y + j >= 0 && p.X + i < CellsHeight)
                {
                    var shipPart = GetCell(new Point(p.X + i, p.Y + j)).ShipPart;
                    if (shipPart != null && shipPart.Ship != part.Ship)
                        return true;
                }

        return false;
    }

    private Cell[,] _cells { get; set; }

    public Cell GetCell(Point shipPoint)
    {
        return _cells[shipPoint.Y, shipPoint.X];

    }
}