using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public enum Status { Play, Enough }

    // Класс игрок
    class Player
    {
        List<Card> cards;
        public int Loss { get; set; }
        public int Win { get; set; }

        public Status State { get; set; }

        public Player ()
        {
            Loss = 0;
            Win = 0;
            cards = new List<Card>();
            State = Status.Play;
        }
        // Взять карту
        public void TakeCard (Card card)
        {
            if (card == null)
                return;
            cards.Add(card);   
        }
        // Отказаться от последней карты
        public void Refuse ()
        {
            cards.RemoveAt(cards.Count - 1);
        }

        // Показать все карты
        public void ShowCard ()
        {
            for (int i = 0; i < cards.Count; i++ )
              Console.WriteLine("{0})\t{1}-{2}", i+1, cards[i].Suit, cards[i].Value);
            Console.WriteLine("Счет = {0}", GetSpot());
        }
        // Получить счет карт
        public int GetSpot ()
        { 
            int sm = 0;
            foreach (Card card in cards)
            {
                switch (card.Value)
                {
                    case Values.two:   sm += 2;  break;
                    case Values.three: sm += 3;  break;
                    case Values.four:  sm += 4;  break;
                    case Values.five:  sm += 5;  break;
                    case Values.six:   sm += 6;  break;
                    case Values.seven: sm += 7; break;
                    case Values.eight: sm += 8; break;
                    case Values.nine:  sm += 9; break;
                    case Values.ten:   sm += 10; break;
                    case Values.knave: sm += 10; break;
                    case Values.queen: sm += 10; break;
                    case Values.king:  sm += 10; break;
                    case Values.ace:   sm += 11; break;
                }
            }
            return sm;
        }
        // Сдать все карты (очистка коллекции)
        public void GiveBackCards ()
        {
            cards.Clear();
        }
        // Сказать достаточно
        public void SayEnough()
        {
            State = Status.Enough;
        }
        public int CountCards()
        {
            return cards.Count();
        }
    }
}
