namespace SeaBattle;

public class Ship
{
    public Ship(int size)
    {
        Parts = new ShipPart[size];
        for (int i = 0; i < Parts.Length; i++)
            Parts[i] = new ShipPart(this);
    }

    public int Size => Parts.Length;
    public ShipPart[] Parts { get; set; }

    public bool IsAlive()
    {
        return Parts.Any(part => part.IsAlive);
    }
}