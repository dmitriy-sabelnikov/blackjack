﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public static class MenuGame
    {
        private static void ShowAllDeck(Deck deck)
        {
            for (int i = 0; i < deck.DeckCards.Count; i++)
                Console.WriteLine("{0}) \t{1}-{2}", i + 1, deck.DeckCards[i].Suit, deck.DeckCards[i].CardValue);
        }

        private static void StartRound(Deck deck, Game game)
        {
            game.StartRound();
            deck.FillDeck();
            deck.Shuffle();
        }

        private static void Shuffle (Deck deck)
        {
            deck.Shuffle();
        }

        private static void ClearScore (Game game, Player gamer)
        {
            game.ClearScore(gamer);
        }

        public static void InitMenu (Deck deck, Game game, Croupier croupier, Player gamer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ConsoleKeyInfo cki;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t Меню");
                Console.WriteLine("\t\t\t F1  - Показать карты");
                Console.WriteLine("\t\t\t F2  - Тасовать карты");
                Console.WriteLine("\t\t\t F3  - Сбросить счет игры");
                Console.WriteLine("\t\t\t F4  - Начать раунд");
                Console.WriteLine("\t\t\t F10 - Выход");
                cki = WorkKey.GetPressKey();
                Console.Clear();
                if (WorkKey.CompareKey(cki, ConsoleKey.F1))
                {
                    ShowAllDeck(deck);
                }
                if (WorkKey.CompareKey(cki, ConsoleKey.F2))
                {
                    Shuffle (deck);
                    Console.WriteLine("Колода потасована");
                }
                if (WorkKey.CompareKey(cki, ConsoleKey.F3))
                {
                    ClearScore(game, gamer);
                    Console.WriteLine("Счет сброшен");
                }
                if (WorkKey.CompareKey(cki, ConsoleKey.F4))
                {
                    StartRound(deck, game);
                }
                if (WorkKey.CompareKey(cki, ConsoleKey.F10))
                {
                    break;
                }
                else
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
