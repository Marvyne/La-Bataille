using La_Bataille_Console;
using La_Bataille_Console.Class;
using La_Bataille_Console.Function;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static La_Bataille_Console.Class.Cards;

namespace La_Bataille_UnitTest
{
    [TestClass]
    public class UnitTestPackage
    {
       

        [TestMethod]
        public void Test_Init_Package_Should_Find_List_Of_52_Cards()
        {
            Package function = new Package();
            List<Cards> package = function.InitPackage();
            int nb_card = package.Count;
            Assert.AreEqual(52, nb_card);
        }

        [TestMethod]
        public void Test_Init_Package_Should_Find_All_Cards_In_Package()
        {
            Package function = new Package();
            List<Cards> package = function.InitPackage();
            int nb_card_found = 0;
            foreach (enumValue value in Enum.GetValues(typeof(enumValue)))
            {
                foreach (enumColor color in Enum.GetValues(typeof(enumColor)))
                {
                    Cards actual_card = package.Where(x => x._Color == color && x._Value == value).First();
                    if (actual_card != null)
                        nb_card_found++;
                }
            }
            Assert.AreEqual(52, nb_card_found);
        }

        [TestMethod]
        public void Test_Sort_Package_Should_Find_Disorder_List_Of_5_Cards()
        {
            Package function = new Package();
            List<Cards> card_test_shuffle = new List<Cards>();
            card_test_shuffle.Add(new Cards((enumColor)1, (enumValue)1));
            card_test_shuffle.Add(new Cards((enumColor)2, (enumValue)2));
            card_test_shuffle.Add(new Cards((enumColor)3, (enumValue)3));
            card_test_shuffle.Add(new Cards((enumColor)4, (enumValue)4));
            card_test_shuffle.Add(new Cards((enumColor)1, (enumValue)5));

            List<Cards> shuffled = function.ShufflePackage(card_test_shuffle);
            int ignores = 0;
            for (int i = 0; i < card_test_shuffle.Count; i++)
            {
                if (card_test_shuffle[i] == shuffled[i])
                    ignores++;
            }
            Assert.AreNotEqual(5, ignores);

        }
    }
}
