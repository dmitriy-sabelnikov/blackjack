using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public static class WorkKey
    {
        public static ConsoleKeyInfo GetPressKey()
        {
            return Console.ReadKey();
        }

        public static bool CompareKey(ConsoleKeyInfo cki, ConsoleKey pressKey)
        {
            if (cki.Key == pressKey)
            {
                return true;
            }
            return false;
        }
    }
}
