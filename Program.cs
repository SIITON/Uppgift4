﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Uppgift4
{
    public enum Pokerhands
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
    class Program
    {
        
        public static Dictionary<int, string> TypeOfHand = new Dictionary<int, string>();  
        static void Main(string[] args)
        {
            DefineTypesOfPokerHands();
            do
            {
                Console.WriteLine("Let's deal some cards til we get a nice hand!");
                PrintPossibleHandsToSearchFor();
                Hand wantedHand = LetUserDecideWantedHand();
                Console.WriteLine("Shuffling & dealing..");
                var stopwatch = Stopwatch.StartNew();
                var poker = new PokerAnalyzer(wantedHand);
                poker.Run();
                var elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
                var avgShufflesPerSecond = poker.NumOfShuffles / elapsedTotalSeconds;

                Console.WriteLine($"Done!");
                Console.WriteLine($"- Time:       {elapsedTotalSeconds:N3} s");
                Console.WriteLine($"- Shuffles:   {poker.NumOfShuffles}");
                Console.WriteLine($"- Shuffles/s: {avgShufflesPerSecond:N1}");
                poker.ShowHand();
            } while (UserWantsToRunAgain());
            
        }

        private static void DefineTypesOfPokerHands()
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

        private static void PrintPossibleHandsToSearchFor()
        {
            Console.WriteLine("+-----------------------+");
            Console.WriteLine("| Key : Type of hand    |");
            Console.WriteLine("+-----------------------+");
            string format;
            foreach (var item in TypeOfHand)
            {
                format = String.Format("|  {0}  : {1,15} |", item.Key, item.Value);
                Console.WriteLine(format);
            }
            Console.WriteLine("+-----------------------+");
        }

        private static Hand LetUserDecideWantedHand()
        {
            int typeofhand = 0;
            bool isInRange = false;
            while (!isInRange)
            {
                Console.Write("Select key: ");
                if (int.TryParse(Console.ReadLine(), out typeofhand))
                {
                    isInRange = (typeofhand >= 0 && typeofhand < 10) ? true : false;
                }
                if(!isInRange)
                {
                    Console.WriteLine("Invalid key, try again");
                }
            }
            Console.WriteLine($"Let's get a {TypeOfHand[typeofhand]}!");
            return new FakePokerHands(typeofhand).GetHand();
        }
        public static bool UserWantsToRunAgain()
        {
            Console.WriteLine("\nRun again? (Y/n)");
            var userInput = Console.ReadLine();
            var result = false;
            switch (userInput)
            {
                case "Y":
                    result = true;
                    break;
                case "y":
                    result = true;
                    break;
                case "N":
                    result = false;
                    break;
                case "n":
                    result = false;
                    break;
                default:
                    Console.WriteLine("Invalid response, quitting.");
                    result = false;
                    break;
            }
            Console.Clear();
            return result;
        }
    }
}
