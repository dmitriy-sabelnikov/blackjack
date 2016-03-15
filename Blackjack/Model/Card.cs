using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    // Масть
    enum Suits { Club, Diamond, Heart, Spade }; /* Трефа, Бубна, Черва, Пика*/
    // Значение карт
    enum Values
    {
        two, three, four, five, six, seven, eight, nine,
        ten, knave, queen, king, ace
    }
    // класс карта
    class Card
    {
        public Suits Suit { get; set; }
        public Values Value { get; set; }
    }
}
