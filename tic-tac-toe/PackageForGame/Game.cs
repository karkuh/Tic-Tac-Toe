using System;
using System.Collections.Generic;
using tic_tac_toe.Enums;
using tic_tac_toe.PackageForPlayers;

namespace tic_tac_toe.PackageForGame
{
    public abstract class Game
    {
        protected Game()
        {
            Results = new List<GameHistory>();
            Random = new Random();
        }

        protected TypeGame TypeGame { get; set; } 

        protected readonly Random Random ;
        protected List<GameHistory> Results { get;}
        public abstract void PlayingGame(Account player1, Account player2, int rating);
        public abstract void RealPlayingGame(Account player1, Account player2, int rating, int result);
        
    }
}