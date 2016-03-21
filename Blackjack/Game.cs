using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Game
    {
        private Croupier _croupier;
        private Player _gamer;
        private Deck _deck;
        private int _croupierSpot = 0;
        private int _gamerSpot = 0;

        private void ShowPlayersCards(Croupier croupier, Player gamer)
        {
            PrintInfo.PrintOtherMes(TypeMessage.CardCroupier);
            PrintInfo.PrintCards(croupier.PlayerCards);
            PrintInfo.PrintSpot(PlayerSpot(croupier));

            PrintInfo.PrintOtherMes(TypeMessage.CardPlayer); 
            PrintInfo.PrintCards(gamer.PlayerCards);
            PrintInfo.PrintSpot(PlayerSpot(gamer));
        }

        private void GiveCard(Croupier player, int countCard)
        {
            for (int i = 0; i < countCard; i++)
            {
                player.TakeCard(_deck.GetCard());
            }
        }

        private void FinishRound(ResultGame res)
        {
            _gamer.State = StatusPlayer.Play;
            _croupier.State = StatusPlayer.Play;
            _gamer.GiveBackCards();
            _croupier.GiveBackCards();
            if (res == ResultGame.Draw)
            {
                PrintInfo.PrintResult(ResultGame.Draw);
            }
            if (res == ResultGame.Loss)
            {
                _gamer.Loss += 1;
                PrintInfo.PrintResult(ResultGame.Loss);
            }
            if (res == ResultGame.Win)
            {
                _gamer.Win += 1;
                PrintInfo.PrintResult(ResultGame.Win);
            }
        }

        private int PlayerSpot(Croupier player)
        {
            int spot = 0;
            for (int i = 0; i < player.PlayerCards.Count; i++)
                spot += player.PlayerCards[i].Point;
            return spot;
        }

        private void StepCoupier()
        {
            // Croupier must say enough while spot more then 17 point
            while (_croupier.State == StatusPlayer.Play)
            {
                if (PlayerSpot(_croupier) > 17)
                {
                    _croupier.State = StatusPlayer.Enough;
                    break;
                }
                PrintInfo.PrintOtherMes(TypeMessage.StepCroupier);
                GiveCard(_croupier, 1);
                ShowPlayersCards(_croupier, _gamer);
            }
        }

        private void CroupierTakeSecondCard()
        {
            PrintInfo.PrintOtherMes(TypeMessage.StepCroupier);
            GiveCard(_croupier, 1);
            ShowPlayersCards(_croupier, _gamer);
        }

        private void GamerMustSayEnough(Player gamer, int spot)
        {
            if (spot >= 21)
            {
                gamer.State = StatusPlayer.Enough;
            }
        }

        private void StepGamerTakeOneCard(Player gamer)
        {
            GiveCard(gamer, 1);
            ShowPlayersCards(_croupier, gamer);
            GamerMustSayEnough(gamer, PlayerSpot(gamer));
        }

        private void StepGamerRefuseOneCard(Player gamer)
        {
            gamer.Refuse();
            GiveCard(gamer, 2);
            ShowPlayersCards(_croupier, gamer);
            GamerMustSayEnough(gamer, PlayerSpot(gamer));
        }

        private void StepGamer()
        {
            ConsoleKeyInfo cki;
            while (_gamer.State == StatusPlayer.Play)
            {
                PrintInfo.PrintOtherMes(TypeMessage.MenuPlayer);
                cki = WorkKey.GetPressKey();
                //Gamer take one card
                if (WorkKey.CompareKey(cki, ConsoleKey.F5))
                {
                    StepGamerTakeOneCard(_gamer);
                }
                //Gamer refuse one card
                if (WorkKey.CompareKey(cki, ConsoleKey.F6))
                {
                }
                // Gamer say Enough
                if (WorkKey.CompareKey(cki, ConsoleKey.F7))
                {
                    _gamer.State = StatusPlayer.Enough;
                }
            }
        }

        private void ResultBlackJack(int croupierSpot, int gamerSpot)
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

        private void InitRound(Croupier croupier, Player gamer)
        {
            PrintInfo.PrintScore(gamer.Win, gamer.Loss);
            GiveCard(gamer, 2);
            GiveCard(croupier, 1);
            ShowPlayersCards(croupier, gamer); 
        }

        private ConsoleKeyInfo ChooseGamerDraw()
        {
            ConsoleKeyInfo cki;
            while (true)
            {
                PrintInfo.PrintOtherMes(TypeMessage.FinishRound);
                cki = WorkKey.GetPressKey();
                if (WorkKey.CompareKey(cki, ConsoleKey.Y) || WorkKey.CompareKey(cki, ConsoleKey.N))
                {
                    break;
                }
            }
            return cki;
        }


        public Game(Croupier croupier, Player gamer, Deck deck)
        {
            this._croupier = croupier;
            this._gamer = gamer;
            this._deck = deck;
        }

        public void ClearScore(Player gamer)
        {
            gamer.Loss = 0;
            gamer.Win = 0;
        }

        public void StartRound()
        {
            InitRound(_croupier, _gamer);
            _gamerSpot = PlayerSpot(_gamer);
            _croupierSpot = PlayerSpot(_croupier);
            // if gamer has 21 spot and croupier has less 10 then win
            if (_gamerSpot == 21 && _croupierSpot < 10)
            {
                FinishRound(ResultGame.Win);
                return;
            }
            // if gamer has 21 spot and croupier has 10 or 11 then gamer can say Draw
            if (_gamerSpot == 21 && (_croupierSpot == 10 || _croupierSpot == 11))
            {
                if (WorkKey.CompareKey(ChooseGamerDraw(), ConsoleKey.Y))
                {
                    FinishRound(ResultGame.Draw);
                    return;
                }
            }
            StepGamer ();
            _gamerSpot = PlayerSpot(_gamer);
            if (_gamerSpot > 21)
            {
                FinishRound(ResultGame.Loss);
                return;
            }
            CroupierTakeSecondCard();
            _croupierSpot = PlayerSpot(_croupier);
            // Croupier take second card and if croupier's spot = 21 then loss
            if (_croupierSpot == 21)
            {
                FinishRound(ResultGame.Loss);
                return;
            }
            StepCoupier ();
            _gamerSpot = PlayerSpot(_gamer);
            _croupierSpot = PlayerSpot(_croupier);
            ResultBlackJack(_croupierSpot, _gamerSpot);
        }
    }
}
