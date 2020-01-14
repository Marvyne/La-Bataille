using La_Bataille_Console.Class;
using La_Bataille_Console.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static La_Bataille_Console.Class.Cards;

namespace La_Bataille_Console.Function
{
    public class Package : IPackage
    {
        private Random rd = new Random();
        /// <summary>
        /// Init package of 52 cards
        /// </summary>
        /// <returns></returns>
        public List<Cards> InitPackage()
        {
            List<Cards> package = new List<Cards>();
            foreach (enumValue value in Enum.GetValues(typeof(enumValue)))
            {
                foreach (enumColor color in Enum.GetValues(typeof(enumColor)))
                    package.Add(new Cards(color, value));
            }
            return package;
        }

        /// <summary>
        /// Shuffle the cards package
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public List<Cards> ShufflePackage(List<Cards> cards)
        {
            return cards.OrderBy(a => rd.Next()).ToList();
        }
    }
}