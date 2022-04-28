namespace SeaBattle;

public class Cell
{
    public bool IsShooted { get; set; }
    public ShipPart ShipPart { get; set; }

    public void Shoot()
    {
        throw new NotImplementedException();
    }
}