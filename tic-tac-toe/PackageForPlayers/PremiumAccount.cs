using tic_tac_toe.Enums;
using tic_tac_toe.PackageForGame;

namespace tic_tac_toe.PackageForPlayers
{
    public class PremiumAccount : Account
    {
        public PremiumAccount(string firstName, string lastName, string userName, string password) : base(firstName,
            lastName, userName, password)
        {
            TypeAccount = TypeAccount.Преміум;
        }

        public override void WinGame(TypeGame typeGame, GameHistory game, Account oponent)
        {
            var beforeRating = CurrentRating;
            CurrentRating += game.Rating * 2;
            Results.Add(new PlayerHistory(typeGame, game.Id, game.Rating, GameOutcome.WIN, oponent, beforeRating,
                CurrentRating));
        }

        public override void LoseGame(TypeGame typeGame, GameHistory game, Account oponent)
        {
            var beforeRating = CurrentRating;
            CurrentRating -= game.Rating / 2;
            Results.Add(new PlayerHistory(typeGame, game.Id, game.Rating, GameOutcome.LOSE, oponent, beforeRating,
                CurrentRating));
        }
    }
}