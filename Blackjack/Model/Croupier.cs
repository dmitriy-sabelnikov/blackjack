using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Croupier 
    {
        public List<Card> PlayerCards {get; set;}
        public int Loss { get; set; }
        public int Win { get; set; }

        public StatusPlayer State { get; set; }

        public Croupier()
        {
            Loss = 0;
            Win = 0;
            PlayerCards = new List<Card>();
            State = StatusPlayer.Play;
        }

        public void TakeCard(Card card)
        {
            if (card == null)
                return;
            PlayerCards.Add(card);
        }
        // Clear List Card
        public void GiveBackCards()
        {
            PlayerCards.Clear();
        }

        public void SayEnough()
        {
            State = StatusPlayer.Enough;
        }
    }
}
