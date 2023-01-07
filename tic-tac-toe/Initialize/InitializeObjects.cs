using tic_tac_toe.PackageForGame;
using tic_tac_toe.PackageForPlayers;
using tic_tac_toe.Services;

namespace tic_tac_toe.Initialize;

public class InitializeObjects
{
    public  AccountService AccountService { get;  }

    public  ClassicGame ClassicGame { get;  }

    public  GameForOne GameForOne { get;  }

    public  TrainingGame TrainingGame { get;  }

    public  Account TrainingBot { get;  }

    public InitializeObjects()
    {
        AccountService = new AccountService();
        ClassicGame = new ClassicGame();
        GameForOne = new GameForOne();
        TrainingGame = new TrainingGame();
        TrainingBot = new Account("---", "---", "TrainingBot", "secretPassword");
    }
}