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
                case 2:
                    CreateTwoPair();
                    break;
                case 3:
                    CreateThreeOfAKind();
                    break;
                case 4:
                    CreateStraight();
                    break;
                case 5:
                    CreateFlush();
                    break;
                case 8:
                    CreateStraightFlush();
                    break;
                case 9:
                    CreateRoyalFlush();
                    break;
                default:
                    CreateThreeOfAKind();
                    break;
            }
            
        }

        private void CreateFlush()
        {
            _hand.AddCard(1, "Diamonds");
            _hand.AddCard(10, "Hearts");
            _hand.AddCard(11, "Hearts");
            _hand.AddCard(12, "Hearts");
            _hand.AddCard(13, "Hearts");
        }

        private void CreateRoyalFlush()
        {
            _hand.AddCard(1, "Hearts");
            _hand.AddCard(10, "Hearts");
            _hand.AddCard(11, "Hearts");
            _hand.AddCard(12, "Hearts");
            _hand.AddCard(13, "Hearts");
        }

        private void CreateStraightFlush()
        {
            _hand.AddCard(4, "Spades");
            _hand.AddCard(5, "Spades");
            _hand.AddCard(7, "Spades");
            _hand.AddCard(6, "Spades");
            _hand.AddCard(8, "Spades");
        }

        private void CreateTwoPair()
        {
            _hand.AddCard(4, "Clover");
            _hand.AddCard(8, "Spades");
            _hand.AddCard(4, "Hearts");
            _hand.AddCard(6, "Diamonds");
            _hand.AddCard(8, "Clover");
        }

        private void CreateStraight()
        {
            _hand.AddCard(4, "Clover");
            _hand.AddCard(5, "Spades");
            _hand.AddCard(7, "Hearts");
            _hand.AddCard(6, "Diamonds");
            _hand.AddCard(8, "Clover");
        }

        private void CreateThreeOfAKind()
        {
            _hand.AddCard(12, "Clover");
            _hand.AddCard(5, "Spades");
            _hand.AddCard(5, "Hearts");
            _hand.AddCard(10, "Diamonds");
            _hand.AddCard(5, "Clover");
        }

        private void CreatePair()
        {
            _hand.AddCard(10, "Clover");
            _hand.AddCard(5, "Spades");
            _hand.AddCard(1, "Hearts");
            _hand.AddCard(10, "Diamonds");
            _hand.AddCard(2, "Clover");
        }

        public Hand GetHand()
        {
            return _hand;
        }
    }
}
