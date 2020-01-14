using La_Bataille_Console.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace La_Bataille_Console.Interface
{
    public interface IDisplay
    {
        void AnnounceLoseOfGamer(Gamer gamer);
        void AnnounceWinner(Game game, Gamer winner);
        void AnnounceRank(Gamer gamer);
        Game GetInfoGame();
        void InfoDistributePackage(int party, int nbGamer);
        void InfoLostACard(Gamer gamer, Cards cardLost);
        void InfoLostMultipleCards(Gamer gamer, List<Cards> cardLos);
        void InfoWinCards(Gamer gamer, List<Cards> cardsWin);
        void WhoGameWhat(Gamer gamer, Cards card);
        

    }
}
