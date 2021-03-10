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
    }
}