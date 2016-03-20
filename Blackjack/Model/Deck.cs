using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blackjack
{
    public class Deck 
    {
        public List<Card> DeckCards {get; set;}

        public Deck ()
        {
            DeckCards = new List<Card>();
            FillDeck ();
        }      

        public void FillDeck ()
        {
            DeckCards.Clear();
            for (Suit suit = Suit.Club; suit <= Suit.Spade; suit++ )
            {
                int point = 2;
                for (CardValue value = CardValue.Two; value <= CardValue.Ace; value++)
                {
                    DeckCards.Add(new Card() { Suit = suit, CardValue = value, Point = point });
                    if (value < CardValue.Ten || value >= CardValue.King)
                    {
                        point++;
                    }
                }
            }
        }

        public void Shuffle ()
        {
            Random rnd = new Random();
            for (int i = 0; i < DeckCards.Count; i++)
            {
                int j = rnd.Next(0, i);
                Card bufferCard = DeckCards[i];
                DeckCards[i] = DeckCards[j];
                DeckCards[j] = bufferCard;
            }
        }

        public Card GetCard()
        {
            Card returnCard = DeckCards[DeckCards.Count-1];
            DeckCards.Remove(returnCard);
            return returnCard;
        }
    }
}
