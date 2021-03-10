using System;
using System.Collections.Generic;
using System.Linq;
using Uppgift4.Extensions;

namespace Uppgift4
{
    public class Hand
    {
        public IEnumerable<ICard> Cards { get; set; }
        public List<int> Values { get; private set; }
        public List<string> Faces { get; private set; }
        public List<int> RankOfHand { get; private set; }
        public int HighCard { get; private set; }
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
        public Hand()
        {
            Values = new List<int>();
            Faces = new List<string>();
        }
        public void AddCard(int value, string face)
        {
            Values.Add(value);
            Faces.Add(face);
            if (Values.Count >= 5)
            {
                Analyze();
            }
        }

        private void Analyze()
        {
            var ranks = new List<int>();
            var pair_values = Values.Duplicates();
            if (pair_values.Count() == 1)
            {
                ranks.Add((int)Pokerhands.Pair);
            }
            if (pair_values.Count() == 2)
            {
                ranks.Add((int)Pokerhands.TwoPair);
            }
            if (Values.Triplets().Count() == 1)
            {
                ranks.Add((int)Pokerhands.ThreeOfAKind);
            }
            if (Values.Quadruplets().Count() == 1)
            {
                ranks.Add((int)Pokerhands.FourOfAKind);
            }
            if (Values.IsStraight())
            {
                ranks.Add((int)Pokerhands.Straight);
            }
            if (Faces.IsFlush())
            {
                ranks.Add((int)Pokerhands.Flush);
            }

            HighCard = (Values.Min() == 1) ? 14 : Values.Max();
            if (HighCard == 14)
            {
                ranks.Add((int)Pokerhands.HighCard);
            }
            if (ranks.Contains((int)Pokerhands.ThreeOfAKind) && ranks.Contains((int)Pokerhands.Pair))
            {
                ranks.Add((int)Pokerhands.FullHouse);
            }

            if (ranks.Contains((int)Pokerhands.Straight) && ranks.Contains((int)Pokerhands.Flush))
            {
                ranks.Add((int)Pokerhands.StraightFlush);
            }
            if (ranks.Contains((int)Pokerhands.StraightFlush) && Values.Max() == 13 && HighCard == 14)
            {
                ranks.Add((int)Pokerhands.RoyalFlush);
            }
            RankOfHand = ranks;
        }
    }
}