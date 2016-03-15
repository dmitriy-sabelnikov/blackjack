using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    // Класс игрок
    class Player : Croupier    
    {
        // Отказаться от последней карты
        public void Refuse ()
        {
            cards.RemoveAt(cards.Count - 1);
        }
    }
}
