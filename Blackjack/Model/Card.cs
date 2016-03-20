using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        public Suit Suit { get; set; }
        public CardValue CardValue { get; set; }
        public int Point { get; set; }
    }
}
