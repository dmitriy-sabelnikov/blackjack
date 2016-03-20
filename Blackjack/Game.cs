using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Game
    {
        Croupier croupier;
        Player gamer;
        Deck deck;
        int croupierSpot;
        int gamerSpot;

        void ShowPlayersCards(Croupier croupier, Player gamer)
        {
            PrintInfo.PrintOtherMes(TypeMessage.CardCroupier);
            PrintInfo.PrintCards(croupier.cards);
            PrintInfo.PrintSpot(PlayerSpot(croupier));

            PrintInfo.PrintOtherMes(TypeMessage.CardPlayer); 
            PrintInfo.PrintCards(gamer.cards);
            PrintInfo.PrintSpot(PlayerSpot(gamer));
        }
        
        void GiveCard(Croupier player, int countCard)
        {
            for (int i = 0; i < countCard; i++ )
                player.TakeCard(deck.GetCard());
        }

        void FinishRound (ResultGame res)
        {
            gamer.State = Status.Play;
            croupier.State = Status.Play;
            gamer.GiveBackCards();
            croupier.GiveBackCards();
            if (res == ResultGame.Draw)
            {
                PrintInfo.PrintResult(ResultGame.Draw);
            }
            if (res == ResultGame.Loss)
            {
                gamer.Loss += 1;
                PrintInfo.PrintResult(ResultGame.Loss);
            }
            if (res == ResultGame.Win)
            {
                gamer.Win += 1;
                PrintInfo.PrintResult(ResultGame.Win);
            }
        }

        int PlayerSpot(Croupier player)
        {
            int spot = 0;
            for (int i = 0; i < player.cards.Count; i++)
                spot += player.cards[i].Point;
            return spot;
        }

        void StepCoupier ()
        {
            // Croupier must say enough while spot more then 17 point
            while (croupier.State == Status.Play)
            {
                if (PlayerSpot(croupier) > 17)
                {
                    croupier.State = Status.Enough;
                    break;
                }
                PrintInfo.PrintOtherMes(TypeMessage.StepCroupier);
                GiveCard(croupier, 1);
                ShowPlayersCards(croupier, gamer);
            }
        }

        void CroupierTakeSecondCard()
        {
            PrintInfo.PrintOtherMes(TypeMessage.StepCroupier);
            GiveCard(croupier, 1);
            ShowPlayersCards(croupier, gamer);
        }
 
        void GamerMustSayEnough (Player gamer, int spot)
        {
            if (spot >= 21)
            {
                gamer.State = Status.Enough;
            }
        }

        void StepGamerTakeOneCard (Player gamer)
        {
            GiveCard(gamer, 1);
            ShowPlayersCards(croupier, gamer);
            GamerMustSayEnough(gamer, PlayerSpot(gamer));
        }

        void StepGamerRefuseOneCard (Player gamer)
        {
            gamer.Refuse();
            GiveCard(gamer, 2);
            ShowPlayersCards(croupier, gamer);
            GamerMustSayEnough(gamer, PlayerSpot(gamer));
        }

        void StepGamer ()
        {
            ConsoleKeyInfo cki;
            while (gamer.State == Status.Play)
            {
                PrintInfo.PrintOtherMes(TypeMessage.MenuPlayer);
                cki = WorkKey.GetPressKey();
                //Gamer take one card
                if (WorkKey.CompareKey(cki, ConsoleKey.F5))
                {
                    StepGamerTakeOneCard(gamer);
                }
                //Gamer refuse one card
                if (WorkKey.CompareKey(cki, ConsoleKey.F6))
                {
                }
                // Gamer say Enough
                if (WorkKey.CompareKey(cki, ConsoleKey.F7))
                {
                    gamer.State = Status.Enough;
                }
            }
        }

        void ResultBlackJack (int croupierSpot, int gamerSpot)
        {
            if (gamerSpot > 21)
            {
                FinishRound(ResultGame.Loss);
                return;
            }
            if (croupierSpot > 21 || gamerSpot > croupierSpot)
            {
                FinishRound(ResultGame.Win);
                return;
            }
            if (gamerSpot < croupierSpot)
            {
                FinishRound(ResultGame.Loss);
                return;
            }
            if (gamerSpot == croupierSpot)
            {
                FinishRound(ResultGame.Draw);
                return;
            }
        }

        void InitRound (Croupier croupier, Player gamer)
        {
            PrintInfo.PrintScore(gamer.Win, gamer.Loss);
            GiveCard(gamer, 2);
            GiveCard(croupier, 1);
            ShowPlayersCards(croupier, gamer); 
        }

        ConsoleKeyInfo ChooseGamerDraw ()
        {
            ConsoleKeyInfo cki;
            do
            {
                PrintInfo.PrintOtherMes(TypeMessage.FinishRound);
                cki = WorkKey.GetPressKey();
            }
            while (WorkKey.CompareKey(cki, ConsoleKey.Y) && WorkKey.CompareKey(cki, ConsoleKey.N));
            return cki;
        }


        public Game(Croupier croupier, Player gamer, Deck deck)
        {
            this.croupier = croupier;
            this.gamer = gamer;
            this.deck = deck;
        }

        public void ClearScore(Player gamer)
        {
            gamer.Loss = 0;
            gamer.Win = 0;
        }

        public void StartRound()
        {
            InitRound(croupier, gamer);
            gamerSpot = PlayerSpot(gamer);
            croupierSpot = PlayerSpot(croupier);
            // if gamer has 21 spot and croupier has less 10 then win
            if (gamerSpot == 21 && croupierSpot < 10)
            {
                FinishRound(ResultGame.Win);
                return;
            }
            // if gamer has 21 spot and croupier has 10 or 11 then gamer can say Draw
            if (gamerSpot == 21 && (croupierSpot == 10 || croupierSpot == 11))
            {
                if (WorkKey.CompareKey(ChooseGamerDraw(), ConsoleKey.Y))
                {
                    FinishRound(ResultGame.Draw);
                    return;
                }
            }
            StepGamer ();
            gamerSpot = PlayerSpot(gamer);
            if (gamerSpot > 21)
            {
                FinishRound(ResultGame.Loss);
                return;
            }
            CroupierTakeSecondCard();
            croupierSpot = PlayerSpot(croupier);
            // Croupier take second card and if croupier's spot = 21 then loss
            if (croupierSpot == 21)
            {
                FinishRound(ResultGame.Loss);
                return;
            }
            StepCoupier ();
            gamerSpot = PlayerSpot(gamer);
            croupierSpot = PlayerSpot(croupier);
            ResultBlackJack(croupierSpot, gamerSpot);
        }
    }
}
