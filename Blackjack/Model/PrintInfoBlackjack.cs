using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class PrintInfoBlackjack : IPrintInfo 
    {
        public void PrintCards(List<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
                Console.WriteLine("{0})\t{1}-{2}", i + 1, cards[i].Suit, cards[i].Value);
        }

        public void PrintScore(int win, int loss)
        {
            Console.WriteLine("Счет: Победа : Поражение    {0}:{1}", win, loss);
        }

        public void PrintResult(ResultGame resGame)
        {
            switch (resGame)
            {
                case ResultGame.Draw: Console.WriteLine("Ничья! Раунд завершен"); break;
                case ResultGame.Loss: Console.WriteLine("Вы проиграли! Раунд завершен"); break;
                case ResultGame.Win: Console.WriteLine("Поздравляю. Вы выйграли! Раунд завершен"); break;
            }
        }

        public void PrintSpot (int spot)
        {
            Console.WriteLine("Счет = {0}", spot);
        }

        public void PrintOtherMes(TypeMessage typeMsg)
        {
            switch (typeMsg)
            {
                case TypeMessage.stepCrp: Console.WriteLine("Ход крупье"); break;
                case TypeMessage.stepPlr: Console.WriteLine("Ход игрока");  break;
                case TypeMessage.CardCrp: Console.WriteLine("Карты крупье"); break;
                case TypeMessage.CardPlr: Console.WriteLine("Карты игрока"); break;
                case TypeMessage.MenuPlr: 
                    Console.WriteLine("F5 - взять карту, F6 - отказаться от последней карты,"+ 
                    "F7 - сказать достаточно\n"); break;
                case TypeMessage.FinishRound:
                    Console.WriteLine("Вы можете закончить раунд. Ничья (y/n)?");
                    break;
            }
        }
    
    }
}
