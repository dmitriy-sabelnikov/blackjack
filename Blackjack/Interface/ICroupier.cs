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
        List<Card> cards { get; set; }// Карты игрока
        int Loss { get; set; }        // Количество поражений
        int Win { get; set; }         // Количество побед
        Status State { get; set; }    // Статус игрока
        void TakeCard(Card card);     // Взять карту
        int GetSpot();                // Получить счет карт
        void GiveBackCards();         // Сдать все карты (очистка коллекции)
        void SayEnough();             // Сказать достаточно
        int CountCards();             // Количество карт
    }
}
