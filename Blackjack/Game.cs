using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    // Класс игра
    class Game
    {
        Player croupier; 
        Player gamer; 
        
        public Game ()
        {
            croupier = new Player();
            gamer = new Player();
        }
        public void ClearScore()
        {
            gamer.Loss = 0;
            gamer.Win = 0;
        }

        public void StartRound(Deck deck)
        {
            Console.WriteLine("Счет: Победа : Поражение    {0}:{1} \n", gamer.Win, gamer.Loss);
            // Сдаем две карты игроку 
            gamer.TakeCard(deck.GetCard());
            gamer.TakeCard(deck.GetCard());
            //одну - крупье
            croupier.TakeCard(deck.GetCard());
            Console.WriteLine("Карты игрока");
            gamer.ShowCard();
            Console.WriteLine("Карты крупье");
            croupier.ShowCard();
            // если на руках 21 очко и у крупье не выше 10 очков то выйгрыш
            ConsoleKeyInfo cki;

            if (gamer.GetSpot() == 21 && croupier.GetSpot() < 10)
            {
                gamer.Win += 1;
                gamer.GiveBackCards();
                croupier.GiveBackCards();
                gamer.State = Status.Play;
                Console.WriteLine("Поздравляю. Вы выйграли! Раунд завершен");
                return;
            }
            // если у крупье 10 или 11 очков, тогда игрок может забрать свою ставку (ничья)
            if (gamer.GetSpot() == 21 && croupier.GetSpot() >= 10)
            {
                do
                {
                    Console.WriteLine("Вы можете закончить раунд. Ничья (y/n)?");
                    cki = Console.ReadKey();
                }
                while (cki.Key != ConsoleKey.Y && cki.Key != ConsoleKey.N);

                if (cki.Key == ConsoleKey.Y)
                {
                    gamer.GiveBackCards();
                    croupier.GiveBackCards();
                    gamer.State = Status.Play;
                    Console.WriteLine("Ничья! Раунд завершен");
                    return;
                }
            }
            Console.WriteLine("\nХод игрока");
            Console.WriteLine("F5 - взять карту, F6 - отказаться от последней карты, F7 - сказать достаточно\n");
            while (gamer.State == Status.Play)
            {
                cki = Console.ReadKey();
                switch (cki.Key) 
                {   // взять карту
                    case ConsoleKey.F5: 
                        gamer.TakeCard(deck.GetCard());
                        Console.WriteLine("Карты игрока");
                        gamer.ShowCard();
                        Console.WriteLine("Карты крупье");
                        croupier.ShowCard();
                        if (gamer.GetSpot() >= 21)
                            gamer.State = Status.Enough;
                        else
                            Console.WriteLine("F5 - взять карту, F6 - отказаться от последней карты, F7 - сказать достаточно\n");
                        break;
                    // отказаться от последней карты    
                    case ConsoleKey.F6:
                        gamer.Refuse();
                        gamer.TakeCard(deck.GetCard());
                        gamer.TakeCard(deck.GetCard());
                        Console.WriteLine("Карты игрока");
                        gamer.ShowCard();
                        Console.WriteLine("Карты крупье");
                        croupier.ShowCard();
                        if (gamer.GetSpot() >= 21)
                            gamer.State = Status.Enough;
                        else
                            Console.WriteLine("F5 - взять карту, F6 - отказаться от последней карты, F7 - сказать достаточно\n");
                        break;
                    // сказать достаточно 
                    case ConsoleKey.F7: gamer.State = Status.Enough; break;
                }
            }
            // Если перебор, то проигрыш
            if (gamer.GetSpot() > 21)
            {
                gamer.Loss += 1;
                gamer.GiveBackCards();
                croupier.GiveBackCards();
                gamer.State = Status.Play;
                Console.WriteLine("Вы проиграли! Раунд завершен");
                return;
            }
            // если со второй карты у крупье 21, то проигрыщ
            Console.WriteLine("\nХод крупье");
            croupier.TakeCard(deck.GetCard());
            Console.WriteLine("Карты игрока");
            gamer.ShowCard();
            Console.WriteLine("Карты крупье");
            croupier.ShowCard();
            if (croupier.GetSpot() == 21)
            {
                gamer.Loss += 1;
                gamer.GiveBackCards();
                croupier.GiveBackCards();
                gamer.State = Status.Play;
                Console.WriteLine("Вы проиграли! Раунд завершен");
                return;
            }
            // крупье обязан остановиться пока не достигнет счета больше 17
            while (croupier.GetSpot() <= 17)
            {
                Console.WriteLine("\nХод крупье");
                croupier.TakeCard(deck.GetCard());
                Console.WriteLine("Карты игрока");
                gamer.ShowCard();
                Console.WriteLine("Карты крупье");
                croupier.ShowCard();
            }

            if (croupier.GetSpot() > 21 || gamer.GetSpot() > croupier.GetSpot() )
            {
                gamer.Win += 1;
                gamer.GiveBackCards();
                croupier.GiveBackCards();
                gamer.State = Status.Play;
                Console.WriteLine("Поздравляю. Вы выйграли! Раунд завершен");
                return;
            }
            else if (gamer.GetSpot() < croupier.GetSpot())
            {
                gamer.Loss += 1;
                gamer.GiveBackCards();
                croupier.GiveBackCards();
                gamer.State = Status.Play;
                Console.WriteLine("Вы проиграли! Раунд завершен");
                return;
            }
            else if (gamer.GetSpot() == croupier.GetSpot() )
            {
                gamer.GiveBackCards();
                croupier.GiveBackCards();
                gamer.State = Status.Play;
                Console.WriteLine("Draw! Round completed");
                return;
            }
        }

    }
}
