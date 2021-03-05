using System;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift4
{
    class Program
    {
        private static IHand _hand { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Let's deal some cards til we get a straight flush!");
            //var wantedHand = Console.ReadLine();
            
            var poker = new PokerAnalyzer(_hand);
            while (!poker.WantedHandDealt)
            {
                poker.DealHand();
                poker.CheckHand();
            }
            Console.WriteLine("Done!");
            Console.WriteLine($"Hand given after {poker.NumOfShuffles} shuffles.");
            Console.WriteLine(poker.ShowHand());
            
            //do
            //{
            //    deck.Shuffle();
            //    _hand.Values = deck.DealCards();
            //} while (_hand.NotEqualTo(wantedHand));
            //_hand.ShowCards();
        }
    }
}
