﻿namespace Kuhpik
{
    public enum GameStateID
    {
        // Don't change int values in the middle of development.
        // Otherwise all of your settings in inspector can be messed up.

        Loading = 0,
        TapToStart = 1,
        Game = 2,
        Victory = 3,
        Lose = 10,
        Shop = 20,
        Settings = 30,
        Shared = 100
        

        // Extend just like that
        //
        // Revive = 100,
        // QTE = 200
    }
}