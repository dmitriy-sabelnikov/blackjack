using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blackjack
{
    class Deck 
    {
        public List<Card> cards {get; set;}

        public Deck ()
        {
            cards = new List<Card>();
            FillDeck ();
        }      

        public void FillDeck ()
        {
            cards.Clear();
            for (Suits suit = Suits.Club; suit <= Suits.Spade; suit++ )
            {
                for (Values value = Values.Two; value <= Values.Ace; value++)
                {
                    int point = 0;
                    switch (value)
                    {
                        case Values.Two: point = 2; break;
                        case Values.Three: point = 3; break;
                        case Values.Four: point = 4; break;
                        case Values.Five: point = 5; break;
                        case Values.Six: point = 6; break;
                        case Values.Seven: point = 7; break;
                        case Values.Eight: point = 8; break;
                        case Values.Nine: point = 9; break;
                        case Values.Ten: point = 10; break;
                        case Values.Knave: point = 10; break;
                        case Values.Queen: point = 10; break;
                        case Values.King: point = 10; break;
                        case Values.Ace: point = 11; break;
                    }
                    cards.Add(new Card() { Suit = suit, Value = value, Point = point });
                }
            }
        }

        public void Shuffle ()
        {
            Random rnd = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int j = rnd.Next(0, i);
                Card bufferCard = cards[i];
                cards[i] = cards[j];
                cards[j] = bufferCard;
            }
        }

        public Card GetCard()
        {
            Card returnCard = cards[cards.Count-1];
            cards.Remove(returnCard);
            return returnCard;
        }
    }
}
