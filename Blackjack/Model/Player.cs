﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player : Croupier    
    {
        public void Refuse ()
        {
            cards.RemoveAt(cards.Count - 1);
        }
    }
}
