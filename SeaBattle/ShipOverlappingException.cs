using System.Drawing;

namespace SeaBattle;

public class ShipOverlappingException: Exception
{
    public Point OverlapPoint { get;}

}