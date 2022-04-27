using System.Drawing;

namespace SeaBattle;

public class ShipOverlappingException: Exception
{
    public Point OverlapPoint { get;}

    public ShipOverlappingException(Point overlapPoint)
    {
        OverlapPoint = overlapPoint;
    }
}