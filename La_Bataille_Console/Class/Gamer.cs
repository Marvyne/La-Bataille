using La_Bataille_Console.Interface;
using La_Bataille_Console.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace La_Bataille_Console.Class
{
    public class Gamer
    {
        public string _Name { get; set; }
        public List<Cards> _CardDeck { get; set; }
        public int _Rank { get; set; }

        public Gamer()
        {
        }

        public Gamer(string Name)
        {
            _Name = Name;
        }

        public Gamer(string Name, List<Cards> CardDeck)
        {
            _Name = Name;
            _CardDeck = CardDeck;
        }

        public Gamer(string Name, List<Cards> CardDeck, int Rank)
        {
            _Name = Name;
            _CardDeck = CardDeck;
            _Rank = Rank;
        }

     
        public Cards GameNLastCard(int n)
        {
            try
            {
                return _CardDeck.Count >= n ? _CardDeck.ElementAt(_CardDeck.Count - n) : null;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new Exception("Deck of player empty for this index !!!\n" + e);
            }
        }

        public void RemoveLastCard()
        {
            Cards card = GameNLastCard(1);
            IDisplay display = DisplayViewSingleton.Instance;
            display.InfoLostACard(this, card);
            _CardDeck.Remove(card);
           
        }

        public void RemoveNCard(int index, int nb)
        {
            if (index >= 0)
            {
                Cards card = GameNLastCard(1);
                IDisplay display = DisplayViewSingleton.Instance;
                display.InfoLostMultipleCards(this, _CardDeck.GetRange(index, nb));
                _CardDeck.RemoveRange(index, nb);
            }
            

        }

        public void AddCards(List<Cards> cards)
        {
            IDisplay display = DisplayViewSingleton.Instance;
            display.InfoWinCards(this, cards);
            _CardDeck.InsertRange(0,cards);
        }

        public void AttributeRank(List<Gamer> gamers)
        {
            this._Rank = gamers.Count() - gamers.Where(x => x._Rank != 0).Count();
            IDisplay display = DisplayViewSingleton.Instance;
            display.AnnounceLoseOfGamer(this);
        }
    }
}
