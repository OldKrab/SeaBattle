namespace SeaBattle;

public class ShipPart
{
    public ShipPart(Ship ship)
    {
        Ship = ship;
        IsAlive = true;
    }

    public Ship Ship { get; set; }
    public bool IsAlive { get; set; }
}