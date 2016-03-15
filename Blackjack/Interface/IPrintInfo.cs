using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    enum ResultGame { Win, Loss, Draw }
    enum TypeMessage { stepCrp, stepPlr, CardCrp, CardPlr, MenuPlr, FinishRound }

    interface IPrintInfo
    {
        void PrintCards(List<Card> cards);         // Печатать карты
        void PrintScore(int win, int loss);        // Печатать счет
        void PrintResult(ResultGame resGame);      // Печатать результат игры 
        void PrintSpot(int spot);                  // Печатать количество очков карт 
        void PrintOtherMes(TypeMessage typeMsg);   // Печатать вспомогательный сообщения
    }
}
