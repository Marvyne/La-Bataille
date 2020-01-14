using La_Bataille_Console.Function;
using La_Bataille_Console.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace La_Bataille_Console.Singleton
{
    public sealed class DisplayViewSingleton
    {
        private static readonly object padlock = new object();
        private static IDisplay _Instance = null;
        DisplayViewSingleton()
        {
        }
        
        public static IDisplay Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new Display();
                    }
                    return _Instance;
                }
            }
        }
    }
}
