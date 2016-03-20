using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    static class PrintInfo  
    {
        public static void PrintCards(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine("{0})\t{1}-{2}", i + 1, cards[i].Suit, cards[i].Value);
            }
        }

        public static void PrintScore(int win, int loss)
        {
            Console.WriteLine("Счет: Победа : Поражение    {0}:{1}", win, loss);
        }

        public static void PrintResult(ResultGame resGame)
        {
            if (resGame == ResultGame.Draw)
            {
                Console.WriteLine("Ничья! Раунд завершен");
            }
            if (resGame == ResultGame.Loss)
            {
                Console.WriteLine("Вы проиграли! Раунд завершен");
            }
            if (resGame == ResultGame.Win)
            {
                Console.WriteLine("Поздравляю. Вы выйграли! Раунд завершен");
            }
        }

        public static void PrintSpot(int spot)
        {
            Console.WriteLine("Счет = {0}", spot);
        }

        public static void PrintOtherMes(TypeMessage typeMsg)
        {
            if ( typeMsg == TypeMessage.StepCroupier)
            {
                Console.WriteLine("Ход крупье");
            }
            if (typeMsg == TypeMessage.StepPlayer)
            {
                Console.WriteLine("Ход игрока");
            }
            if (typeMsg == TypeMessage.CardCroupier)
            {
                Console.WriteLine("Карты крупье");
            }
            if (typeMsg == TypeMessage.CardPlayer)
            {
                Console.WriteLine("Карты игрока");
            }
            if (typeMsg == TypeMessage.MenuPlayer)
            {
                Console.WriteLine("F5 - взять карту, F6 - отказаться от последней карты, F7 - сказать достаточно\n");
            }
            if (typeMsg == TypeMessage.FinishRound)
            {
                Console.WriteLine("Вы можете закончить раунд. Ничья (y/n)?");
            }
        }
    }
}
