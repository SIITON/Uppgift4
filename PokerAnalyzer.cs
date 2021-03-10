using System;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift4
{
    internal class PokerAnalyzer
    {
        public bool WantedHandDealt { get; private set; }
        public int NumOfShuffles { get; private set; }
        private Hand _wantedHand { get; set; }
        private Hand _hand;
        private DeckOfCards _deck;
        public static Dictionary<int, string> TypeOfHand = new Dictionary<int, string>();
        public PokerAnalyzer(Hand wantedhand)
        {
            _wantedHand = wantedhand;
            _deck = new DeckOfCards();
            NumOfShuffles = 0;
            WantedHandDealt = false;
        }

        public void CheckHand()
        {
            var trueforall = _wantedHand.RankOfHand.TrueForAll(c => _hand.RankOfHand.Contains(c));
            if (trueforall)
            {
                WantedHandDealt = true;
            }     
        }

        public void ShowHand()
        {
            Console.WriteLine("+---------------+");
            for (int i = 0; i < _hand.Values.Count; i++)
            {
                var format = String.Format("| {0,2} : {1,8} |", _hand.Values[i], _hand.Faces[i]);
                Console.WriteLine(format);
            }
            Console.WriteLine("+---------------+");
            Console.WriteLine($"Highest rank: {_hand.RankOfHand.Max()}");
            Console.WriteLine($"Highcard: {_hand.HighCard}");
        }

        public void Run()
        {
            while (!WantedHandDealt)
            {
                DealNewHand();
                CheckHand();
            }
        }

        public void DealNewHand()
        {
            _deck.Shuffle();
            NumOfShuffles++;
            var topFiveCards = _deck.Order.Take(5).ToList();
            var hand = new Hand();
            foreach (var card in topFiveCards)
            {
                var face = _deck.GetFace(card);
                var value = _deck.GetValue(card);
                hand.AddCard(value, face); 
            }
            _hand = hand;
        }
        public static void DefineTypesOfPokerHands()
        {
            TypeOfHand.Add((int)Pokerhands.HighCard, "High Card (Ace)");
            TypeOfHand.Add((int)Pokerhands.Pair, "Pair");
            TypeOfHand.Add((int)Pokerhands.TwoPair, "Two Pair");
            TypeOfHand.Add((int)Pokerhands.ThreeOfAKind, "Three Of A Kind");
            TypeOfHand.Add((int)Pokerhands.Straight, "Straight");
            TypeOfHand.Add((int)Pokerhands.Flush, "Flush");
            TypeOfHand.Add((int)Pokerhands.FullHouse, "Full House");
            TypeOfHand.Add((int)Pokerhands.FourOfAKind, "Four Of A Kind");
            TypeOfHand.Add((int)Pokerhands.StraightFlush, "Straight Flush");
            TypeOfHand.Add((int)Pokerhands.RoyalFlush, "Royal Flush");
        }

        public static void PrintPossibleHandsToSearchFor()
        {
            Console.WriteLine("+-----------------------+");
            Console.WriteLine("| Key : Type of hand    |");
            Console.WriteLine("+-----------------------+");
            foreach (var item in TypeOfHand)
            {
                Console.WriteLine(String.Format("|  {0}  : {1,15} |", item.Key, item.Value));
            }
            Console.WriteLine("+-----------------------+");
        }

        public static Hand LetUserDecideWantedHand()
        {
            int typeofhand = 0;
            bool isInRange = false;
            while (!isInRange)
            {
                Console.Write("Select key: ");
                if (int.TryParse(Console.ReadLine(), out typeofhand))
                {
                    isInRange = (typeofhand >= 0 && typeofhand < 10);
                }
                if (!isInRange)
                {
                    Console.WriteLine("Invalid key, try again");
                }
            }
            Console.WriteLine($"Let's get a {TypeOfHand[typeofhand]}!");
            return new FakePokerHands(typeofhand).GetHand();
        }
    }
}