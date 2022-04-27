namespace SeaBattle;

public class Field
{
    public List<Ship> Ships { get; set; }
    public ShipPart[,] Cells { get; set; }

    public static int DefaultSize = 10;
}