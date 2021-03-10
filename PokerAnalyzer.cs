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
                Console.WriteLine("Found hand!");
                WantedHandDealt = true;
            }     
        }

        public void ShowHand()
        {
            for (int i = 0; i < _hand.Values.Count; i++)
            {
                Console.WriteLine($"{_hand.Values[i]}:{_hand.Faces[i]}");
            }
            Console.WriteLine($"Highest rank: {_hand.RankOfHand.Max()}");
            Console.WriteLine($"Highcard: {_hand.HighCard}");
            
        }

        public void DealHand()
        {
            _deck.Shuffle();
            NumOfShuffles++;
            var top_cards = _deck.DealtCards();
            var hand = new Hand();
            foreach (var card in top_cards)
            {
                var face = _deck.GetFace(card);
                var value = _deck.GetValue(card);
                hand.AddCard(value, face); 
            }
            _hand = hand;
        }
    }
}