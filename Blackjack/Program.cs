using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Game game = new Game();
            Deck deck = new Deck();
            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t Меню");
                Console.WriteLine("\t\t\t F1  - Показать карты");
                Console.WriteLine("\t\t\t F2  - Тасовать карты");
                Console.WriteLine("\t\t\t F3  - Сбросить счет игры");
                Console.WriteLine("\t\t\t F4  - Начать раунд");
                Console.WriteLine("\t\t\t F10 - Выход");

                cki = Console.ReadKey();
                switch (cki.Key)
                {   // Показать всю колоду
                    case ConsoleKey.F1:
                        Console.Clear();
                        for (int i = 0; i < deck.CountCard; i++ )
                            Console.WriteLine("{0}) \t{1}-{2}", i+1, deck[i].Suit, deck[i].Value);

                        Console.ReadKey();
                        break;
                    // Помешать колоду
                    case ConsoleKey.F2:
                        Console.Clear();
                        deck.Shuffle();
                        Console.WriteLine("Колода потасована");
                        Console.ReadKey();
                        break;
                    // Сбросить счет 
                    case ConsoleKey.F3:
                        Console.Clear();
                        game.ClearScore();
                        Console.WriteLine("Счет сброшен");
                        Console.ReadKey();
                        break;
                    // Начать раунд 
                    case ConsoleKey.F4:
                        Console.Clear();
                        game.StartRound(deck);
                        Console.ReadKey();
                        deck.RestoreDeck();
                        deck.Shuffle();
                        break;

                }

            }
            while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.F10);
        }
    }
}
