using System;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift4
{
    public class DeckOfCards
    {
        private Dictionary<int, int> Value = new Dictionary<int, int>();
        private Dictionary<int, string> Face = new Dictionary<int, string>();
        public int[] Order { get; set; }
        private Random r = new Random();
        public DeckOfCards()
        {
            Order = new int[52];
            for (int i = 0; i < Order.Length; i++)
            {
                Order[i] = i;
            }
            CreateDeck(Order.Length);
        }

        private void CreateDeck(int length)
        {
            int key = 0;
            var faces = new List<string>{ "Spades", "Clover", "Hearts", "Diamonds" };
            for (int i = 0; i < 4; i++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    Value.Add(key, value);
                    Face.Add(key, faces[i]);
                    key++;
                }
            }
        }
        // Returns the top 5 cards in the deck
        public List<int> DealtCards()
        {
            return Order.Take(5).ToList();
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
        }

        public int GetValue(int card)
        {
            return Value[card];
        }
        public string GetFace(int card)
        {
            return Face[card];
        }
    }
}