﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Card
    {
        public Suits Suit { get; set; }
        public Values Value { get; set; }
        public int Point { get; set; }
    }
}
