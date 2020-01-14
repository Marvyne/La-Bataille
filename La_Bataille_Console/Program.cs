using La_Bataille_Console.Class;
using La_Bataille_Console.Function;
using La_Bataille_Console.Interface;
using La_Bataille_Console.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;

namespace La_Bataille_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IDisplay display = DisplayViewSingleton.Instance;
            Trick trick = new Trick();
            Package package = new Package();
            List<Cards> cardPackage = new List<Cards>();

            Game game = display.GetInfoGame();

            for (int i = 0; i < game._PartyNumber; i++)
            {
                cardPackage = package.InitPackage();
                cardPackage = package.ShufflePackage(cardPackage);
                game.InitDeckOfGamer(game._GamerNumber, cardPackage);
                display.InfoDistributePackage(i, game._GamerNumber);

                while (game.GetNumberOfGamerWhoHaveNotLose() != 1)
                {
                    trick.EveryBodyGameACard(ref game);
                    trick.CheckEmptyDeck(ref game);
                }
                Gamer winner = game._Gamer.Where(x => x._Rank == 0).First();
                winner.AttributeRank(game._Gamer);
                display.AnnounceWinner(game, winner);
            }
        }
    }
}
