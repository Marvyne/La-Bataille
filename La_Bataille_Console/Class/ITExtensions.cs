using System;
using System.Collections.Generic;
using System.Text;

namespace La_Bataille_Console.Class
{
    public static class IEnumerableExtensions
    {
        public static void AddTo<T>(this List<T> destination, T self)
        {
            if (self != null) destination.Add(self);
        }
    }
}
