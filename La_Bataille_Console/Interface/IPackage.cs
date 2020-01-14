using La_Bataille_Console.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace La_Bataille_Console.Interface
{
    interface IPackage
    {
        List<Cards> InitPackage();

        List<Cards> ShufflePackage(List<Cards> cards);
    }
}
