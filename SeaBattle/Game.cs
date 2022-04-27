namespace SeaBattle;

public class Game
{
    public Player CurrentPlayer { get;  }
    public Player OtherPlayer { get; }

    public Game()
    {
        CurrentPlayer = new Player();
        OtherPlayer = new Player();
    }
}