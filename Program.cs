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
            TypeOfHand.Add((int)Pokerhands.HighCard,        "High Card");
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

        private static void PrintPossibleHandsToSearchFor()
        {
            Console.WriteLine("+-----------------------+");
            Console.WriteLine("| Key : Type of hand    |");
            Console.Write(("+").PadRight(24, '-'));
            Console.WriteLine("+");
            string format;
            foreach (var item in TypeOfHand)
            {
                format = String.Format("|  {0}  : {1,15} |", item.Key, item.Value);
                Console.WriteLine(format);
            }
            Console.Write(("+").PadRight(24, '-'));
            Console.WriteLine("+");
        }

        private static Hand LetUserDecideWantedHand()
        {
            Console.Write("Select key: ");
            int typeofhand;
            while (!int.TryParse(Console.ReadLine(), out typeofhand))
            {
                Console.WriteLine("Invalid key, try again");
            }
            Console.WriteLine($"Let's get a {TypeOfHand[typeofhand]}!");
            return new FakePokerHands(typeofhand).GetHand();
        }
    }
}
