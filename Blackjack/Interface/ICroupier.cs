using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public enum Status { Play, Enough }

    interface ICroupier
    {
        List<Card> cards { get; set; }
        int Loss { get; set; }
        int Win { get; set; }
        Status State { get; set; }
        void TakeCard(Card card);
        int GetSpot();
        void GiveBackCards();
        void SayEnough();
        int CountCards();
    }
}
