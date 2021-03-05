using System;
using System.Collections.Generic;

namespace Uppgift4
{
    internal class PokerAnalyzer
    {
        private List<int> Values { get; set; }
        public bool WantedHandDealt { get; private set; }
        public int NumOfShuffles { get; private set; }

        private IHand _wantedHand;
        private DeckOfCards _deck;

        public PokerAnalyzer(IHand hand)
        {
            _wantedHand = hand;
            _deck = new DeckOfCards();
            NumOfShuffles = 0;
        }

        internal void CheckHand()
        {
            throw new NotImplementedException();
        }

        internal bool ShowHand()
        {
            throw new NotImplementedException();
        }

        internal void DealHand()
        {
            _deck.Shuffle();
            NumOfShuffles++;
            Values = _deck.DealtCards();
            foreach (var item in Values)
            {
                Console.WriteLine(item);
                Console.WriteLine($"");
            }
            Console.WriteLine("Done");
        }
    }
}