using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Croupier : ICroupier
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
        // Взять карту
        public void TakeCard(Card card)
        {
            if (card == null)
                return;
            cards.Add(card);
        }
        // Получить счет карт
        public int GetSpot()
        {
            int sm = 0;
            foreach (Card card in cards)
            {
                switch (card.Value)
                {
                    case Values.two: sm += 2; break;
                    case Values.three: sm += 3; break;
                    case Values.four: sm += 4; break;
                    case Values.five: sm += 5; break;
                    case Values.six: sm += 6; break;
                    case Values.seven: sm += 7; break;
                    case Values.eight: sm += 8; break;
                    case Values.nine: sm += 9; break;
                    case Values.ten: sm += 10; break;
                    case Values.knave: sm += 10; break;
                    case Values.queen: sm += 10; break;
                    case Values.king: sm += 10; break;
                    case Values.ace: sm += 11; break;
                }
            }
            return sm;
        }
        // Сдать все карты (очистка коллекции)
        public void GiveBackCards()
        {
            cards.Clear();
        }
        // Сказать достаточно
        public void SayEnough()
        {
            State = Status.Enough;
        }
        // Количество карт
        public int CountCards()
        {
            return cards.Count();
        }
    }
}
