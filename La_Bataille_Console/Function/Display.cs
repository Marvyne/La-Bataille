using La_Bataille_Console.Class;
using La_Bataille_Console.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace La_Bataille_Console.Function
{
    class Display : IDisplay
    {
        public void AnnounceLoseOfGamer(Gamer gamer)
        {
            Console.WriteLine("Le {0} n'a plus de carte. Il est donc arrivé {1} ème", gamer._Name, gamer._Rank);
        }

        public void AnnounceWinner(Game game, Gamer winner)
        {
            Console.WriteLine("\n\nLe joueur {0} à gagné la partie.\nFélicitation !!!!!!", winner._Name);
            Console.WriteLine("\nRappel du classement: ");
            game._Gamer.OrderBy(x => x._Rank).ToList().ForEach(x => AnnounceRank(x));

        }
        public void AnnounceRank(Gamer gamer)
        {
            Console.WriteLine("- Le {0} est arrivé {1} ème.", gamer._Name, gamer._Rank);
        }

        public Game GetInfoGame()
        {
            Game game = new Game();

            Console.WriteLine("Bienvenue dans le monde de la bataille Axioma!");
            Console.WriteLine("Choisissez le nombre de joueurs :");
            game._GamerNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Merci !!!!");
            Console.WriteLine("Maintenant veuillez choisir le nombre de partie à jouer :");
            game._PartyNumber = Convert.ToInt32(Console.ReadLine());

            return game;
        }

        public void InfoDistributePackage(int party, int nbGamer)
        {
            Console.WriteLine("Nous allons démarrer la partie " + party + ".\n");
            Console.WriteLine("Le paquet vient d'être mélangé et distribué en " +  nbGamer + " tas.");
            Console.WriteLine("La Bataille peut commencer");
            Console.WriteLine("");
        }

        public void InfoLostACard(Gamer gamer, Cards cardLost)
        {
            Console.WriteLine("{0} perd le {1} de {2}.", gamer._Name, cardLost._Value, cardLost._Color);
        }

        public void InfoCard( Cards card)
        {
            Console.WriteLine("- le {0} de {1}.", card._Value, card._Color);
        }

        public void InfoLostMultipleCards(Gamer gamer, List<Cards> cardLost)
        {
            Console.WriteLine("\n{0} perd les :", gamer._Name);
            cardLost.ForEach(x => InfoCard(x));
        }

        public void InfoWinCards(Gamer gamer, List<Cards> cardsWin)
        {
            Console.WriteLine("{0} à gagné le :", gamer._Name);
            cardsWin.ForEach(x => InfoCard(x));
        }


        public void WhoGameWhat(Gamer gamer, Cards card)
        {
            Console.WriteLine("{0} a joué un {1} de {2}.", gamer._Name, card._Value, card._Color);
        }
    }
}
