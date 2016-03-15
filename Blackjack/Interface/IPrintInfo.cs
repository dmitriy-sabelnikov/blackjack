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
        void PrintCards(List<Card> cards);
        void PrintScore(int win, int loss);
        void PrintResult(ResultGame resGame);
        void PrintSpot(int spot);
        void PrintOtherMes(TypeMessage typeMsg);
    }
}
