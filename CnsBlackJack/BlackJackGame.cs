using CardLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnsBlackJack
{
    internal class BlackJackGame
    {
        public Player Dealer { get; set; }
        public Player Player { get; set; }
        public Player Current { get; set; }
        public Player Winner { get; set; }
        public CardSet Deck { get; set; }
        public void Hit()
        {
            //Додати поточному гравцю ще карту
            Current.Hand.Add(Deck.Pull());
        }
        public void Start()
        {
            //Роздати карти визначити активного гравця
            Deck = new CardSet();
            Deck.Full();
            Deck.Shuffle();
            Deck.Deal(2);
        }
        public int Points(Player player)
        {
            //Повертає кількість балів поточного гравця
            //2-10 = номінал
            //А -1, або 11
            //J-K = 10
            int handValue = 0;
            int aceCount = 0;

            foreach (Card card in player.Hand)
            {
                if (card.Rank == CardRank.Ace)
                {
                    aceCount++;
                    handValue += 11;
                }
                else if (card.Rank == CardRank.Jack || card.Rank == CardRank.Queen || card.Rank == CardRank.King)
                {
                    handValue += 10;
                }
                else
                {
                    handValue += (int)card.Rank;
                }
            }

            while (aceCount > 0 && handValue > 21)
            {
                handValue -= 10;
                aceCount--;
            }

            return handValue;
        }
        public void Pass()
        {
            //перехід до ділера або до кінця гри
            if (Current == Player)
                Current = Dealer;
            else if (Current == Dealer)
                GetWinner();
        }
        public Player GetWinner()
        {
            //повертає переможця
            Player winner = null;
            int dealerHandValue = Points(Dealer);
            int playerValue = Points(Player);
            if (playerValue > 21)
            {
                Player.Status = WinnerOrLose.Lose;
                winner = Dealer;
            }
            else if (dealerHandValue > 21)
            {
                Player.Status = WinnerOrLose.Win;
                winner = Player;
            }
            else if (playerValue == dealerHandValue)
            {
                Player.Status = WinnerOrLose.Tie;
            }
            else if (playerValue > dealerHandValue)
            {
                Player.Status = WinnerOrLose.Win;
                winner = Player;
            }
            else
            {
                Player.Status = WinnerOrLose.Lose;
                winner = Dealer;
            }
            Winner = winner;
            return winner;
        }
        public void DealerAction()
        {
            //набирає карти, доки не буде 17 быльше не можна
            for (int i = Dealer.Hand.Count; i >= 17; i++)
            {
                Dealer.Hand.Add(Deck.Pull());
            }
        }
    }
}
