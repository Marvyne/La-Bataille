using La_Bataille_Console.Class;
using La_Bataille_Console.Function;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static La_Bataille_Console.Class.Cards;

namespace La_Bataille_UnitTest
{
    [TestClass]
    public class UnitTestTrick
    {
        private Game _game;

        [TestInitialize]
        public void Test_Initialize_Table()
        {
            
            _game = new Game();

            List<Cards> deck = new List<Cards>();
            deck.Add(new Cards(enumColor.Carreau, enumValue.deux));
            deck.Add(new Cards(enumColor.Coeur, enumValue.quatre));
            deck.Add(new Cards(enumColor.Pîque, enumValue.trois));
            deck.Add(new Cards(enumColor.Pîque, enumValue.sept));
            deck.Add(new Cards(enumColor.Carreau, enumValue.huit));
            Gamer gamer1 = new Gamer("Gamer test", deck);

            List<Cards> deck2 = new List<Cards>();
            deck2.Add(new Cards(enumColor.Carreau, enumValue.deux));
            deck2.Add(new Cards(enumColor.Coeur, enumValue.quatre));
            deck2.Add(new Cards(enumColor.Pîque, enumValue.huit));
            deck2.Add(new Cards(enumColor.Pîque, enumValue.neuf));
            deck2.Add(new Cards(enumColor.Carreau, enumValue.dame));
            Gamer gamer2 = new Gamer("Gamer test2", deck2);

            List<Cards> deck3 = new List<Cards>();
            deck3.Add(new Cards(enumColor.Carreau, enumValue.roi));
            deck3.Add(new Cards(enumColor.Coeur, enumValue.neuf));
            deck3.Add(new Cards(enumColor.Pîque, enumValue.cinq));
            deck3.Add(new Cards(enumColor.Pîque, enumValue.quatre));
            deck3.Add(new Cards(enumColor.Trèfle, enumValue.valet));
            Gamer gamer3 = new Gamer("Gamer test3", deck3);

            List<Cards> onTable = new List<Cards>();
            onTable.Add(deck[4]);
            onTable.Add(deck2[4]);
            onTable.Add(deck3[4]);
            _game._CardOnTable = onTable;
            _game._Gamer = new List<Gamer>();
            _game._Gamer.Add(gamer1);
            _game._Gamer.Add(gamer2);
            _game._Gamer.Add(gamer3);
        }


        [TestMethod]
        public void Test_Check_Battle_Should_Be_Battle_True()
        {
            Trick trick = new Trick();
            _game._CardOnTable.Add(new Cards((enumColor)3, (enumValue)10));
            Assert.IsTrue(trick.CheckIfMakeBattle(_game));
        }

        [TestMethod]
        public void Test_Check_Battle_Should_Not_Be_Battle_False()
        {
            Trick trick = new Trick();
            Assert.IsFalse(trick.CheckIfMakeBattle(_game));
        }

        [TestMethod]
        public void Test_Assign_Card_Without_Battle_Should_Find_7_Card_For_Winner()
        {
            Trick trick = new Trick();
            trick.AssignCardWithoutBattle(ref _game);
            Assert.AreEqual(7, _game._Gamer[1]._CardDeck.Count);
        }

        [TestMethod]
        public void Test_Assign_Card_With_Battle_Should_Find_12_Card_For_Winner()
        {
            _game._Gamer[0]._CardDeck[4] = new Cards(enumColor.Pîque, enumValue.dame);
            _game._CardOnTable[0] = new Cards(enumColor.Pîque, enumValue.dame);
            Trick trick = new Trick();
            trick.AssignCardBattle(ref _game);
            Assert.AreEqual(9, _game._Gamer[0]._CardDeck.Count);
        }
    }
}
