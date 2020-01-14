using La_Bataille_Console.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace La_Bataille_Console.Interface
{
    interface ITrick
    {
        void EveryBodyGameACard(ref Game game);
        void PutCardToTable(ref Game game);
        bool CheckIfMakeBattle(Game game);
        void AssignCardWithoutBattle(ref Game game);
        void AssignCardBattle(ref Game game);
        void CheckEmptyDeck(ref Game game);
    }
}
