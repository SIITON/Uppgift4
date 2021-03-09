using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Uppgift4;
using Uppgift4.Extensions;

namespace UnitTestProject1
{
    [TestClass]
    public class Hand_Class
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
		public List<int> Values { get; set; }
		public List<string> Faces { get; set; }

		[TestMethod]
		public void Can_Analyze_No_Pair()
        {
			var val = new List<int>();
			val.Add(4);
			val.Add(8);
			val.Add(3);
			val.Add(2);
			val.Add(1);
			var isPair = false;

			var pair_values = val.Duplicates();
			if (pair_values.Count() == 1)
			{
				isPair = true;
			}

			Assert.IsFalse(isPair);
		}
		[TestMethod]
		public void Can_Analyze_If_Two_Pair()
		{
			var val = new List<int>();
			val.Add(4);
			val.Add(2);
			val.Add(4);
			val.Add(2);
			val.Add(1);
			var isTwoPair = false;

			var pair_values = val.Duplicates();
			if (pair_values.Count() == 2)
			{
				isTwoPair = true;
			}

			Assert.IsTrue(isTwoPair);
		}
		[TestMethod]
		public void Can_Analyze_No_Two_Pair()
		{
			var val = new List<int>();
			val.Add(12);
			val.Add(2);
			val.Add(4);
			val.Add(8);
			val.Add(1);
			var isTwoPair = false;

			var pair_values = val.Duplicates();
			if (pair_values.Count() == 2)
			{
				isTwoPair = true;
			}

			Assert.IsFalse(isTwoPair);
		}
		[TestMethod]
		public void Can_Analyze_If_Straight()
		{
			var val = new List<int>();
			val.Add(3);
			val.Add(5);
			val.Add(7);
			val.Add(4);
			val.Add(6);

			Assert.IsTrue(val.IsStraight());
		}
		[TestMethod]
		public void Can_Analyze_No_Straight()
		{
			var val = new List<int>();
			val.Add(1);
			val.Add(7);
			val.Add(7);
			val.Add(4);
			val.Add(6);

			Assert.IsFalse(val.IsStraight());
		}
		[TestMethod]
		public void Can_Analyze_If_Straight_With_Ace()
		{
			var val = new List<int>();
			val.Add(1);
			val.Add(10);
			val.Add(12);
			val.Add(11);
			val.Add(13);
			
			Assert.IsTrue(val.IsStraight());
		}
		[TestMethod]
		public void Can_Analyze_If_Straight_Flush()
		{
			var val = new List<int>();
			val.Add(1);
			val.Add(10);
			val.Add(12);
			val.Add(11);
			val.Add(13);
			
			var faces = new List<string> { "Spades", "Spades", "Spades", "Spades", "Spades" };
			var isFlush = faces.IsFlush();
			var isStraight = val.IsStraight();
			Assert.IsTrue(isStraight);
            Assert.IsTrue(isFlush);
            Assert.IsTrue(isStraight && isFlush);
		}
		[TestMethod]
		public void Can_Analyze_If_Royal_Flush()
		{
			var hand = new FakePokerHands((int)Pokerhands.RoyalFlush).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.RoyalFlush));
		}
		[TestMethod]
		public void Can_Analyze_No_Royal_Flush()
		{
			var hand = new FakePokerHands((int)Pokerhands.Straight).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.RoyalFlush));
		}
		[TestMethod]
		public void Can_Analyze_No_Flush()
        {
			var isFlush = false;
			var faces = new List<string> { "Spades", "Spades", "Spades", "Hearts", "Diamonds" };
			var distinctFaces = faces.Distinct();
			if (distinctFaces.Count() == 1)
			{
				isFlush = true;
			}

			Assert.IsFalse(isFlush);
		}
		[TestMethod]
		public void Can_Analyze_If_Flush()
		{
			var isFlush = false;
			var faces = new List<string> { "Diamonds", "Diamonds", "Diamonds", "Diamonds", "Diamonds" };
			var distinctFaces = faces.Distinct();
			if (distinctFaces.Count() == 1)
			{
				isFlush = true;
			}

			Assert.IsTrue(isFlush);
		}
	}
}
