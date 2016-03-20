using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Croupier 
    {
        public List<Card> cards {get; set;}
        public int Loss { get; set; }
        public int Win { get; set; }

        public Status State { get; set; }

        public Croupier()
        {
            Loss = 0;
            Win = 0;
            cards = new List<Card>();
            State = Status.Play;
        }

        public void TakeCard(Card card)
        {
            if (card == null)
                return;
            cards.Add(card);
        }
        // Clear List Card
        public void GiveBackCards()
        {
            cards.Clear();
        }

        public void SayEnough()
        {
            State = Status.Enough;
        }
    }
}
