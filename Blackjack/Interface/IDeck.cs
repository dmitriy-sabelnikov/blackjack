using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    interface IDeck
    {
        int CountCard { get;}
        Card this[int index] { get; }
        void FillDeck();
        void Shuffle();
        Card GetCard();
    }
}
