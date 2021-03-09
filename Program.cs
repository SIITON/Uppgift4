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
        static void Main(string[] args)
        {
            Console.WriteLine("Let's deal some cards til we get a straight flush!");
            //var wantedHand = Console.ReadLine();
            var _hand = new FakePokerHands((int)Pokerhands.RoyalFlush).GetHand();
            var stopwatch = Stopwatch.StartNew();
            var poker = new PokerAnalyzer(_hand);
            while (!poker.WantedHandDealt)
            {
                poker.DealHand();
                poker.CheckHand();
            }
            var elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
            var avg = poker.NumOfShuffles / elapsedTotalSeconds;
            Console.WriteLine("Done! Results:");
            Console.WriteLine($"{elapsedTotalSeconds:N2} s, Tries per second: {avg:N1}");
            Console.WriteLine($"Hand given after {poker.NumOfShuffles} shuffles.");
            poker.ShowHand();
            
            //do
            //{
            //    deck.Shuffle();
            //    _hand.Values = deck.DealCards();
            //} while (_hand.NotEqualTo(wantedHand));
            //_hand.ShowCards();
        }
    }
}
