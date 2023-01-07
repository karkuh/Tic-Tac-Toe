using System.Linq;
using tic_tac_toe.Enums;
using tic_tac_toe.PackageForPlayers;

namespace tic_tac_toe.PackageForGame
{
    public class TrainingGame : Game
    {
        public TrainingGame()
        {
            TypeGame = TypeGame.TrainingGame;
        }

        public override void RealPlayingGame(Account player1, Account player2, int rating, int result)
        {
            rating = 0;
            switch (result)
            {
                case 0:
                    Results.Add(new GameHistory(player1, player2, rating, GameOutcome.TIE));
                    player1.TieGame(TypeGame, Results.Last(), player2);
                    player2.TieGame(TypeGame, Results.Last(), player1);
                    break;
                case 1:
                    Results.Add(new GameHistory(player1, player2, rating, GameOutcome.WIN));
                    player1.WinGame(TypeGame, Results.Last(), player2);
                    player2.LoseGame(TypeGame, Results.Last(), player1);
                    break;
                default:
                    Results.Add(new GameHistory(player1, player2, rating, GameOutcome.LOSE));
                    player1.LoseGame(TypeGame, Results.Last(), player2);
                    player2.WinGame(TypeGame, Results.Last(), player1);
                    break;
            }
        }

        public override void PlayingGame(Account player1, Account player2, int rating = 0)
        {
            rating = 0;

            var random = Random.Next(1, 101);

            if (random % 10 == 0)
            {
                Results.Add(new GameHistory(player1, player2, rating, GameOutcome.TIE));
                player1.TieGame(TypeGame, Results.Last(), player2);
                player2.TieGame(TypeGame, Results.Last(), player1);
            }
            else if (random % 2 == 0)
            {
                Results.Add(new GameHistory(player1, player2, rating, GameOutcome.WIN));
                player1.WinGame(TypeGame, Results.Last(), player2);
                player2.LoseGame(TypeGame, Results.Last(), player1);
            }
            else
            {
                Results.Add(new GameHistory(player1, player2, rating, GameOutcome.LOSE));
                player1.LoseGame(TypeGame, Results.Last(), player2);
                player2.WinGame(TypeGame, Results.Last(), player1);
            }
        }
    }
}