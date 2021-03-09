using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift4
{
    public class FakePokerHands
    {
        private Hand _hand { get; set; }
        public FakePokerHands(int rank)
        {
            _hand = new Hand();
            switch (rank)
            {
                case 1:
                    CreatePair();
                    break;
                default:
                    break;
            }
        }

        private void CreatePair()
        {
            _hand.AddCard(10, "Clover");
            _hand.AddCard(5, "Spades");
            _hand.AddCard(1, "Hearts");
            _hand.AddCard(10, "Diamonds");
            _hand.AddCard(2, "Clover");
            Console.WriteLine("Searching for pair");
            foreach (var rank in _hand.RankOfHand)
            {
                Console.WriteLine($"which is rank: {rank}");
            }
            
        }

        public Hand GetHand()
        {
            return _hand;
        }
    }
}
