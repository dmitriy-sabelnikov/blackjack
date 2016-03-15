using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    interface IDeck
    {
        int CountCard { get; }           // Количество карт   
        Card this[int index] { get; }
        void FillDeck();                 // Заполнить колоду
        void Shuffle();                  // тасование карт
        Card GetCard();                  // Сдать карту 
    }
}
