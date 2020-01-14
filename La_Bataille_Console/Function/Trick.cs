using La_Bataille_Console.Class;
using La_Bataille_Console.Interface;
using La_Bataille_Console.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static La_Bataille_Console.Class.Cards;

namespace La_Bataille_Console.Function
{
    public class Trick : ITrick
    {
        private IDisplay display = DisplayViewSingleton.Instance;

        public void EveryBodyGameACard(ref Game game)
        {
            PutCardToTable(ref game);
            if (CheckIfMakeBattle(game))
                AssignCardBattle(ref game);
            else
                AssignCardWithoutBattle(ref game);
        }

        public void PutCardToTable(ref Game game)
        {          
            game._CardOnTable = new List<Cards>();
            Cards currentCard;
            foreach(Gamer gamer in game.GetGamerWhoHaveNotLose())
            {
                currentCard = gamer._CardDeck.Last();//.GameNLastCard(1);
                game._CardOnTable.Add(currentCard);
                display.WhoGameWhat(gamer, currentCard);
            }
        }

        public bool CheckIfMakeBattle(Game game)
        {
            return game.CheckIfSameCardGame()
                && game.CardMaxValueIsDuplicate() ? true : false;
        }

        public void AssignCardWithoutBattle(ref Game game)
        {
            Gamer thGamer = game.GetGamerWithMaxValueOnTable(game);
            thGamer.AddCards(game._CardOnTable.Except(thGamer._CardDeck).ToList());
            game.GetGamerWhoHaveNotLose().Where(gamer => gamer != thGamer).ToList().ForEach(x => x.RemoveLastCard());
        }

        public void AssignCardBattle(ref Game game)
        {
            List<Cards> sameCards = game.GetSameCardGame();
            List<Gamer> battleGamers = game.GetCardsConcernByBattle(sameCards);
            Gamer theGamer = game.GetGamerWitHighestCardOnBattle(battleGamers);
            theGamer.AddCards(game._CardOnTable.Except(theGamer._CardDeck).ToList());
            game._Gamer.Except(battleGamers).ToList().ForEach(x => x.RemoveNCard(x._CardDeck.Count - 1, 1));
            game._Gamer.Intersect(battleGamers).Where(x => x != theGamer).ToList().ForEach(x => x.RemoveNCard(x._CardDeck.Count - 3,3));
        }

        public void CheckEmptyDeck(ref Game game)
        {
            List<Gamer> g = game._Gamer;
            game.GetGamerWhoComeToLose().ForEach(x => x.AttributeRank(g));
        }
    }
}
