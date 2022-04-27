namespace SeaBattle;

public class Game
{
    public Player CurrentPlayer { get; private set; }
    public Player OtherPlayer { get; private set;  }

    public Game()
    {
        CurrentPlayer = new Player();
        OtherPlayer = new Player();
    }

    public void SwitchPlayers()
    {
        (CurrentPlayer, OtherPlayer) = (OtherPlayer, CurrentPlayer);
    }
}
