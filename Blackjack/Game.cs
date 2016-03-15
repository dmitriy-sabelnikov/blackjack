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
        Croupier croupier;
        Player gamer;
        IDeck deck;
        IPrintInfo printInfo;
        // Отобразить информацию о картах крупье и игрока
        void showPlayersCards(Croupier croupier, Player gamer)
        {
            printInfo.PrintOtherMes(TypeMessage.CardCrp);
            printInfo.PrintCards(croupier.cards);
            printInfo.PrintSpot(croupier.GetSpot());

            printInfo.PrintOtherMes(TypeMessage.CardPlr); 
            printInfo.PrintCards(gamer.cards);
            printInfo.PrintSpot(gamer.GetSpot());
        }
        // Финализация игры - Отображение результата, сдача карт игроком/крупье
        void resultGame (ResultGame res)
        {
            gamer.State = Status.Play;
            gamer.GiveBackCards();
            croupier.GiveBackCards();
            switch (res)
            {
                case ResultGame.Draw:
                    printInfo.PrintResult(ResultGame.Draw);
                    break;
                case ResultGame.Loss: 
                    gamer.Loss += 1;
                    printInfo.PrintResult(ResultGame.Loss);
                    break;
                case ResultGame.Win: 
                    gamer.Win += 1;
                    printInfo.PrintResult(ResultGame.Win);
                    break;
            }
        }
        public Game(Croupier croupier, Player gamer, IDeck deck, IPrintInfo printInfo)
        {
            this.croupier = croupier;
            this.gamer = gamer;
            this.deck = deck;
            this.printInfo = printInfo;
        }

        public void ClearScore(Player gamer)
        {
            gamer.Loss = 0;
            gamer.Win = 0;
        }

        public void StartRound()
        {
            printInfo.PrintScore(gamer.Win, gamer.Loss);
            // Сдаем две карты игроку 
            gamer.TakeCard(deck.GetCard());
            gamer.TakeCard(deck.GetCard());
            //одну - крупье
            croupier.TakeCard(deck.GetCard());
            showPlayersCards(croupier, gamer);
 
            // если на руках 21 очко и у крупье не выше 10 очков то выйгрыш
            ConsoleKeyInfo cki;
            if (gamer.GetSpot() == 21 && croupier.GetSpot() < 10)
            {
                resultGame(ResultGame.Win);
                return;
            }
            // если у крупье 10 или 11 очков, тогда игрок может забрать свою ставку (ничья)
            if (gamer.GetSpot() == 21 && croupier.GetSpot() >= 10)
            {
                do
                {
                    printInfo.PrintOtherMes(TypeMessage.FinishRound);
                    cki = Console.ReadKey();
                }
                while (cki.Key != ConsoleKey.Y && cki.Key != ConsoleKey.N);

                if (cki.Key == ConsoleKey.Y)
                {
                    resultGame(ResultGame.Draw);
                    return;
                }
            }
            printInfo.PrintOtherMes(TypeMessage.stepPlr);
            while (gamer.State == Status.Play)
            {
                printInfo.PrintOtherMes(TypeMessage.MenuPlr);
                cki = Console.ReadKey();
                switch (cki.Key) 
                {   // взять карту
                    case ConsoleKey.F5: 
                        gamer.TakeCard(deck.GetCard());
                        showPlayersCards(croupier, gamer);
                        if (gamer.GetSpot() >= 21)
                            gamer.State = Status.Enough;
                        break;
                    // отказаться от последней карты    
                    case ConsoleKey.F6:
                        gamer.Refuse();
                        gamer.TakeCard(deck.GetCard());
                        gamer.TakeCard(deck.GetCard());
                        showPlayersCards(croupier, gamer);
                        if (gamer.GetSpot() >= 21)
                            gamer.State = Status.Enough;
                        break;
                    // сказать достаточно 
                    case ConsoleKey.F7: gamer.State = Status.Enough; break;
                }
            }
            // Если перебор, то проигрыш
            if (gamer.GetSpot() > 21)
            {
                resultGame(ResultGame.Loss);
                return;
            }
            // если со второй карты у крупье 21, то проигрыщ
            printInfo.PrintOtherMes(TypeMessage.stepCrp);
            croupier.TakeCard(deck.GetCard());
            showPlayersCards(croupier, gamer);
            if (croupier.GetSpot() == 21)
            {
                resultGame(ResultGame.Loss);
                return;
            }
            // крупье обязан остановиться пока не достигнет счета больше 17
            while (croupier.GetSpot() <= 17)
            {
                printInfo.PrintOtherMes(TypeMessage.stepCrp);
                croupier.TakeCard(deck.GetCard());
                showPlayersCards(croupier, gamer);
            }

            if (croupier.GetSpot() > 21 || gamer.GetSpot() > croupier.GetSpot() )
            {
                resultGame(ResultGame.Win);
                return;
            }
            else if (gamer.GetSpot() < croupier.GetSpot())
            {
                resultGame(ResultGame.Loss);
                return;
            }
            else if (gamer.GetSpot() == croupier.GetSpot() )
            {
                resultGame(ResultGame.Draw);
                return;
            }
        }
    }
}
