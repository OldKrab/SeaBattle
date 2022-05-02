namespace SeaBattle;

public class Cell
{
    public bool IsShooted { get; set; }
    public ShipPart ShipPart { get; set; }

    public Cell()
    {
        IsShooted = false;
    }

    public void Shoot()
    {
        IsShooted = true;
        ShipPart?.Kill();
    }
} 