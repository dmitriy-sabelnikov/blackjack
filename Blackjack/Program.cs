using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Croupier croupier = new Player();
            Player gamer = new Player();
            Game game = new Game(croupier, gamer, deck);
            MenuGame.InitMenu(deck, game, croupier, gamer);                
        }
    }
}
