using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player : Croupier    
    {
        public void Refuse ()
        {
            PlayerCards.RemoveAt(PlayerCards.Count - 1);
        }
    }
}
