﻿namespace SeaBattle;

public class Player
{
    public Field Field { get; }

    public Player()
    {
        Field = new Field();
    }

    public bool HasAliveShips()
    {
        throw new NotImplementedException();
    }
}