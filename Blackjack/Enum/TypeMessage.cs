using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public enum TypeMessage 
    { 
        None = 0,
        StepCroupier = 1,
        StepPlayer = 2,
        CardCroupier = 3,
        CardPlayer = 4,
        MenuPlayer = 5,
        FinishRound = 6
    }
}
