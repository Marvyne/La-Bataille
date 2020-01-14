using La_Bataille_Console.Class;
using La_Bataille_Console.Function;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static La_Bataille_Console.Class.Cards;

namespace La_Bataille_UnitTest
{
    [TestClass]
    public class UnitTestDeck
    {
        private Gamer _gamer;

        [TestInitialize]
        public void Test_Initialize()
        {

            List<Cards>  deck = new List<Cards>();
            deck.Add(new Cards((enumColor)1, (enumValue)2));
            deck.Add(new Cards((enumColor)2, (enumValue)3));
            deck.Add(new Cards((enumColor)3, (enumValue)4));
            deck.Add(new Cards((enumColor)3, (enumValue)5));
            deck.Add(new Cards((enumColor)1, (enumValue)6));

            _gamer = new Gamer("Gamer test", deck);
        }

        [TestMethod]
        public void Test_Remove_Card_To_Deck_Should_Find_4_Cards_Because_Remove_Last_Card_Of_Deck()
        {
            _gamer.RemoveLastCard();
            int nb_card = _gamer._CardDeck.Count;
            Assert.AreEqual(4, nb_card);
        }


        [TestMethod]
        public void Test_Remove_2_First_Card_To_Deck_Should_Find_3_Cards_Except_First_And_Second_Card()
        {
            _gamer.RemoveNCard(0, 2);
            int nb_card = _gamer._CardDeck.Count;
            Assert.AreEqual(3, nb_card);

            int nb_card_duplicate_of_card_remove = 0;
            List<Cards> two_cards_remove = new List<Cards>();
            two_cards_remove.Add(new Cards((enumColor)1, (enumValue)2));
            two_cards_remove.Add(new Cards((enumColor)2, (enumValue)3));
            nb_card_duplicate_of_card_remove = _gamer._CardDeck.Intersect(two_cards_remove).Count();
            Assert.AreEqual(0, nb_card_duplicate_of_card_remove);
        }

        [TestMethod]
        public void Test_Add_Card_To_Deck_Should_Find_7_Cards_Because_Add_2_Cards()
        {
            List<Cards> cards_to_add = new List<Cards>();
            cards_to_add.Add(new Cards((enumColor)1, (enumValue)9));
            cards_to_add.Add(new Cards((enumColor)2, (enumValue)8));

            _gamer.AddCards(cards_to_add);
            int nb_card = _gamer._CardDeck.Count;
            Assert.AreEqual(7, nb_card);
        }
    }
}
