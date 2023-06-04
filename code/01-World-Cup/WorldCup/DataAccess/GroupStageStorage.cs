﻿using WorldCup.Model;

namespace WorldCup.DataAccess;

public static class GroupStageStorage
{
    public static GroupStage LoadGroupStage(long id)
    {
        // This method retrieves a group stage from the database based on the provided identifier

        var france = new Team(1, "France");
        var australia = new Team(2, "Australia");
        var denmark = new Team(3, "Denmark");
        var tunisia = new Team(4, "Tunisia");

        return new GroupStage()
        {
            Id = id,
            Name = "FIFA WorldCup 2022 - Group D",
            Teams = new List<Team>() { france, australia, denmark, tunisia },
            Games = new List<Game>()
            {
                new Game(denmark, tunisia) { Score1 = 0, Score2 = 0 },
                new Game(france, australia) { Score1 = 4, Score2 = 1 },
                new Game(tunisia, australia) { Score1 = 0, Score2 = 1 },
                new Game(france, denmark) { Score1 = 2, Score2 = 1 },
                new Game(australia, denmark) { Score1 = 1, Score2 = 0 },
                new Game(tunisia, france) { Score1 = 1, Score2 = 0 },
            }
        };
    }
}