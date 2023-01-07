using System.Collections.Generic;
using tic_tac_toe.Enums;
using tic_tac_toe.PackageForGame;

namespace tic_tac_toe.PackageForPlayers
{
    public class Account
    {
        public Account(string firstName, string lastName, string userName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Results = new List<PlayerHistory>();
            TypeAccount = TypeAccount.Класичний;
        }


        public string FirstName { get; }

        public string LastName { get; }
        public string UserName { get; }

        public TypeAccount TypeAccount { get; protected set; }

        public string Password { get; }

        private int _currentRating = 1;

        public int CurrentRating
        {
            get => _currentRating;
            set => _currentRating = value < 1 ? 1 : value;
        }

        public List<PlayerHistory> Results { get; }

        public virtual void WinGame(TypeGame typeGame, GameHistory game, Account oponent)
        {
            var beforeRating = CurrentRating;
            CurrentRating += game.Rating;
            Results.Add(new PlayerHistory(typeGame, game.Id, game.Rating, GameOutcome.WIN, oponent, beforeRating,
                CurrentRating));
        }

        public virtual void LoseGame(TypeGame typeGame, GameHistory game, Account oponent)
        {
            var beforeRating = CurrentRating;
            CurrentRating -= game.Rating;
            Results.Add(new PlayerHistory(typeGame, game.Id, game.Rating, GameOutcome.LOSE, oponent, beforeRating,
                CurrentRating));
        }

        public void TieGame(TypeGame typeGame, GameHistory game, Account oponent)
        {
            Results.Add(new PlayerHistory(typeGame, game.Id, game.Rating, GameOutcome.TIE, oponent, CurrentRating,
                CurrentRating));
        }
    }
}