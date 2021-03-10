using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Uppgift4
{
    class Program
    {
        enum Pokerhands
        {
            HighCard,
            Pair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush,
        }
        public static Dictionary<int, string> TypeOfHand = new Dictionary<int, string>();  
        static void Main(string[] args)
        {
            Console.WriteLine("Let's deal some cards til we get a nice hand!");
            DefineTypesOfPokerHands();
            PrintPossibleHandsToSearchFor();
            Hand wantedHand = LetUserDecideWantedHand();
            var _hand = new FakePokerHands((int)Pokerhands.RoyalFlush).GetHand();
            var stopwatch = Stopwatch.StartNew();
            var poker = new PokerAnalyzer(wantedHand);
            Console.WriteLine("Starting...");
            while (!poker.WantedHandDealt)
            {
                poker.DealHand();
                poker.CheckHand();
            }
            var elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            var avg = poker.NumOfShuffles / elapsedTotalSeconds;

            Console.WriteLine($"Done! In {elapsedTotalSeconds:N2} s, shuffles per second: {avg:N1}");
            Console.WriteLine($"Hand given after {poker.NumOfShuffles} shuffles.");
            poker.ShowHand();
        }

        private static void DefineTypesOfPokerHands()
        {
            TypeOfHand.Add(0, "High Card");
            TypeOfHand.Add(1, "Pair");
            TypeOfHand.Add(2, "Two Pair");
            TypeOfHand.Add(3, "Three Of A Kind");
            TypeOfHand.Add(4, "Straight");
            TypeOfHand.Add(5, "Flush");
            TypeOfHand.Add(6, "Full House");
            TypeOfHand.Add(7, "Four Of A Kind");
            TypeOfHand.Add(8, "Straight Flush");
            TypeOfHand.Add(9, "Royal Flush");
        }

        private static void PrintPossibleHandsToSearchFor()
        {
            Console.WriteLine("Key : Type of hand");
            foreach (var item in TypeOfHand)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }

        private static Hand LetUserDecideWantedHand()
        {
            Console.WriteLine("Select key");
            int typeofhand;
            while (!int.TryParse(Console.ReadLine(), out typeofhand))
            {
                Console.WriteLine("Invalid key, try again");
            }
            return new FakePokerHands(typeofhand).GetHand();
        }
    }
}
