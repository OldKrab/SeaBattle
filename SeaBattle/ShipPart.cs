namespace SeaBattle;

public class ShipPart
{
    public ShipPart(Ship ship)
    {
        Ship = ship;
        IsAlive = true;
    }

    public Ship Ship { get; }
    public bool IsAlive { get; private set; }

    public void Kill()
    {
        IsAlive = false;
    }
}