using System;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift4
{
    public class DeckOfCards
    {
        private Dictionary<int, int> Deck = new Dictionary<int, int>();
        public int[] Order { get; set; }
        private IHand _hand;
        private Random r = new Random();
        public DeckOfCards() //IDeck deck
        {
            Order = new int[52];
            for (int i = 0; i < Order.Length; i++)
            {
                Order[i] = i;
            }
            CreateDeck(Order.Length);
            Console.WriteLine($"Deck of size {Order.Length} initialized.");
        }

        private void CreateDeck(int length)
        {
            int key = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    Deck.Add(key, value);
                    key++;
                }
            }
            
        }

        public List<int> DealtCards()
        {
            var hand = Order.Take(5);
            return hand.OrderBy(num => num).ToList();
        }

        internal void Shuffle()
        {
            // Fisher-Yates shuffle method
            int temp; int k;
            for (int i = Order.Length - 1; i > 0; --i)
            {
                k = r.Next(i + 1);
                temp = Order[i];
                Order[i] = Order[k];
                Order[k] = temp;
            }
            Console.WriteLine("Deck has been shuffled.");
        }
    }
}