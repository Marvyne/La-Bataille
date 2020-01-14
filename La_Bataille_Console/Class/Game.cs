using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static La_Bataille_Console.Class.Cards;

namespace La_Bataille_Console.Class
{
    public class Game
    {
        public int _GamerNumber { get; set; }
        public int _PartyNumber { get; set; }
        public List<Gamer> _Gamer { get; set; }
        public List<Cards> _CardOnTable { get; set; }

        public Game() { }

        public List<Gamer> GetGamerWhoHaveNotLose()
        {
            return _Gamer.Where(x => x._Rank == 0).ToList();
        }

        public List<Gamer> GetGamerWhoComeToLose()
        {
            return _Gamer.Where(x => x._CardDeck.Count() == 0 && x._Rank == 0).ToList();
        }

        public List<Cards> GetSameCardGame()
        {
            return _CardOnTable.GroupBy(x => x._Value).Where(g => g.Count() > 1).SelectMany(r => r).ToList();
        }

        public bool CheckIfSameCardGame()
        {
            return _CardOnTable.Count() != _CardOnTable.Select(x => x._Value).Distinct().Count();
        }

        public bool CardMaxValueIsDuplicate()
        {
            return GetMaxCardValue() == GetDuplicateCardValue() ? true : false;
        }

        public Cards GetCardMax()
        {
            return (from cards in _CardOnTable
                    orderby cards._Value descending
                    select cards).FirstOrDefault();
        }

        public enumValue GetMaxCardValue()
        {
            return _CardOnTable.Select(x => x._Value).Max();
        }

        public enumValue GetDuplicateCardValue()
        {
            return _CardOnTable.GroupBy(x => x._Value)
                    .Where(value => value.Count() > 1)
                    .Select(value => value.Key).FirstOrDefault();
        }

        public List<Gamer> GetCardsConcernByBattle(List<Cards> sameCards)
        {
            List<Gamer> battleGamers = new List<Gamer>();
            sameCards.ForEach(x => battleGamers.Add(GetGamerByCard(x)));
            return battleGamers;
        }

        public Gamer GetGamerWitHighestCardOnBattle(List<Gamer> battleGamers)
        {
            List<Cards> compareCard = new List<Cards>();
            foreach (Gamer gamer in battleGamers)
            {
                _CardOnTable.AddTo(gamer.GameNLastCard(2));
                compareCard.AddTo(gamer.GameNLastCard(3));
            }
            _CardOnTable.AddRange(compareCard);
            return GetGamerByCard(GetCardMax());
        }

        public Gamer GetGamerByCard(Cards card)
        {
            return _Gamer.Where(x => x._CardDeck.Contains(card)).FirstOrDefault();
        }

        public Gamer GetGamerWithMaxValueOnTable(Game game)
        {
            return game._Gamer.Where(x => x.GameNLastCard(1)._Value == game.GetCardMax()._Value).FirstOrDefault();
        }

        public int GetNumberOfGamerWhoHaveNotLose()
        {
            return _Gamer.Where(x => x._Rank == 0).Count();
        }

        public void InitDeckOfGamer(int nbGamer, List<Cards> cards)
        {
            _Gamer = new List<Gamer>();
            int nbCard = cards.Count;
            for (int i = 1; i <= nbGamer; i++)
                _Gamer.Add(new Gamer("Joueur " + i, new List<Cards>()));
            for (int j = 0; j < nbCard; j++)
                _Gamer[j % nbGamer]._CardDeck.Add(cards[j]);
        }

    }
}
