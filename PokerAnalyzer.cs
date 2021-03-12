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
        public List<int> HandsDealt = new List<int>(10);
        public PokerAnalyzer(Hand wantedhand)
        {
            _wantedHand = wantedhand;
            _deck = new DeckOfCards();
            NumOfShuffles = 0;
            WantedHandDealt = false;
            for (int i = 0; i < 10; i++)
            {
                HandsDealt.Add(0);
            }
        }

        public void CheckHand()
        {
            if (_hand.RankOfHand.Contains(_wantedHand.RankOfHand.Max()))
            {
                WantedHandDealt = true;
            }
            if (_hand.RankOfHand.Count != 0)
            {
                AddRankToStatistics(_hand.RankOfHand.Max());
            }
        }

        private void AddRankToStatistics(int rank)
        {
            HandsDealt[rank]++;
        }

        public void ShowHand()
        {
            Console.WriteLine("+----------------+");
            Console.WriteLine("| Val :   Face   |");
            Console.WriteLine("+----------------+");
            for (int i = 0; i < _hand.Values.Count; i++)
            {
                if (_hand.Values[i] == _hand.HighCard || _hand.Values[i] == 1)
                {
                    Console.WriteLine(String.Format("| {0,3} : {1,8} |  <-- High card", _hand.Values[i], _hand.Faces[i]));
                }
                else
                {
                    Console.WriteLine(String.Format("| {0,3} : {1,8} |", _hand.Values[i], _hand.Faces[i]));
                }
            }
            Console.WriteLine("+----------------+");
        }

        public void ShowRankStatistics()
        {
            Console.WriteLine("\nAll hands dealt during search:");
            Console.WriteLine("+--------------------------+");
            int i = 0;
            foreach (var num_of_ranks in HandsDealt)
            {
                Console.WriteLine("| {0,6} : {1,15} |", num_of_ranks, TypeOfHand[i]);
                i++;
            }
            Console.WriteLine("+--------------------------+");
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
            TypeOfHand.Add((int)Pokerhands.HighCard,        "High Card (Ace)");
            TypeOfHand.Add((int)Pokerhands.Pair,            "Pair");
            TypeOfHand.Add((int)Pokerhands.TwoPair,         "Two Pair");
            TypeOfHand.Add((int)Pokerhands.ThreeOfAKind,    "Three Of A Kind");
            TypeOfHand.Add((int)Pokerhands.Straight,        "Straight");
            TypeOfHand.Add((int)Pokerhands.Flush,           "Flush");
            TypeOfHand.Add((int)Pokerhands.FullHouse,       "Full House");
            TypeOfHand.Add((int)Pokerhands.FourOfAKind,     "Four Of A Kind");
            TypeOfHand.Add((int)Pokerhands.StraightFlush,   "Straight Flush");
            TypeOfHand.Add((int)Pokerhands.RoyalFlush,      "Royal Flush");
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
                    Console.WriteLine("Invalid key, try again!");
                }
            }
            Console.WriteLine($"Let's get a {TypeOfHand[typeofhand]}!");
            return new FakePokerHands(typeofhand).GetHand();
        }
    }
}