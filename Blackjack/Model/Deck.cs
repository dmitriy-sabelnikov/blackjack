using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blackjack
{
    // класс колода
    class Deck : IDeck
    {
        public int CountCard { get; private set; } // Количество карт 
        Card[] cards;
        
        public Deck ()
        {
            CountCard = 52;
            cards = new Card[CountCard];
            FillDeck ();
        }
        
        // индексатор
        public Card this[int index]
        {
            get 
            {
                return cards[index];
            }
        }

        
        public void FillDeck ()
        {
            if (CountCard != 52)
                CountCard = 52;
            Suits st = Suits.Club;
            Values val = Values.two;
            for (int i = 0; i < CountCard; i++)
            {
                cards[i] = new Card() { Suit = st, Value = val };

                if (val == Values.ace)
                {
                    val = Values.two;
                    st++;
                }
                else
                {
                    val++;
                }
            }
        }
        // тасование карт
        public void Shuffle ()
        {
            Random rnd = new Random();
            for (int i = 0; i < CountCard; i++)
            {
                int j = rnd.Next(0, i);
                Card tmp = cards[i];
                cards[i] = cards[j];
                cards[j] = tmp;
            }
        }
        // Сдать одну карту 
        public Card GetCard()
        {
            if (CountCard < 0)
                return null;
            Card retCard = cards[CountCard - 1];
            CountCard--;
            return retCard;
        }
    }
}
