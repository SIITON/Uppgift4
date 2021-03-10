using System;
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
        static void Main(string[] args)
        {
            PokerAnalyzer.DefineTypesOfPokerHands();
            do
            {
                Console.WriteLine("Let's deal some cards til we get a nice hand!");
                PokerAnalyzer.PrintPossibleHandsToSearchFor();
                Hand wantedHand = PokerAnalyzer.LetUserDecideWantedHand();
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


        public static bool UserWantsToRunAgain()
        {
            Console.WriteLine("\nRun again? (Y/n)");
            var userInput = Console.ReadLine();
            var result = false;
            switch (userInput)
            {
                case "Y":
                    result = true;
                    Console.Clear();
                    break;
                case "y":
                    result = true;
                    Console.Clear();
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
            return result;
        }
    }
}
