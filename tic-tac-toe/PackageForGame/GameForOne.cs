using System.Linq;
using tic_tac_toe.Enums;
using tic_tac_toe.PackageForPlayers;

namespace tic_tac_toe.PackageForGame
{
    public class GameForOne : Game
    {
        public GameForOne()
        {
            TypeGame = TypeGame.GameForOne;
        }

        public override void RealPlayingGame(Account player1, Account player2, int rating, int result)
        {
            switch (result)
            {
                case 0:
                    Results.Add(new GameHistory(player1, player2, rating, GameOutcome.TIE));
                    player1.TieGame(TypeGame, Results.Last(), player2);
                    player2.TieGame(TypeGame, Results.Last(), player1);
                    break;
                case 1:
                {
                    var game = new GameHistory(player1, player2, 0, GameOutcome.WIN);
                    player2.LoseGame(TypeGame, game, player1);
                    game.Rating = rating;
                    player1.WinGame(TypeGame, game, player2);
                    Results.Add(game);
                    break;
                }
                default:
                {
                    var game = new GameHistory(player1, player2, 0, GameOutcome.LOSE);
                    player2.WinGame(TypeGame, game, player1);
                    game.Rating = rating;
                    player1.LoseGame(TypeGame, game, player2);
                    Results.Add(game);
                    break;
                }
            }
        }


        public override void PlayingGame(Account player1, Account player2, int rating)
        {
            var random = Random.Next(1, 101);

            if (random % 10 == 0)
            {
                Results.Add(new GameHistory(player1, player2, rating, GameOutcome.TIE));
                player1.TieGame(TypeGame, Results.Last(), player2);
                player2.TieGame(TypeGame, Results.Last(), player1);
            }
            else if (random % 2 == 0)
            {
                var game = new GameHistory(player1, player2, 0, GameOutcome.WIN);
                player2.LoseGame(TypeGame, game, player1);
                game.Rating = rating;
                player1.WinGame(TypeGame, game, player2);
                Results.Add(game);
            }
            else
            {
                var game = new GameHistory(player1, player2, 0, GameOutcome.LOSE);
                player2.WinGame(TypeGame, game, player1);
                game.Rating = rating;
                player1.LoseGame(TypeGame, game, player2);
                Results.Add(game);
            }
        }
    }
}