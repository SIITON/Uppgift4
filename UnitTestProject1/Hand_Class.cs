using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Uppgift4;
using Uppgift4.Extensions;

namespace Uppgift4.Tests
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
		public void Can_Analyze_If_Pair()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Pair).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.Pair));
		}
		[TestMethod]
		public void Can_Analyze_No_Pair()
        {
			Hand hand = new FakePokerHands((int)Pokerhands.RoyalFlush).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.Pair));
		}
		[TestMethod]
		public void Can_Analyze_If_Two_Pair()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.TwoPair).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.TwoPair));
		}
		[TestMethod]
		public void Can_Analyze_No_Two_Pair()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Pair).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.TwoPair));
		}
		[TestMethod]
		public void Can_Analyze_If_Straight()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Straight).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.Straight));
		}
		[TestMethod]
		public void Can_Analyze_No_Straight()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Flush).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.Straight));
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
			Hand hand = new FakePokerHands((int)Pokerhands.StraightFlush).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.StraightFlush));
		}
		[TestMethod]
		public void Can_Analyze_If_Royal_Flush()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.RoyalFlush).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.RoyalFlush));
		}
		[TestMethod]
		public void Can_Analyze_No_Royal_Flush()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Straight).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.RoyalFlush));
		}
		[TestMethod]
		public void Can_Analyze_No_Flush()
        {
			Hand hand = new FakePokerHands((int)Pokerhands.Straight).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.Flush));
		}
		[TestMethod]
		public void Can_Analyze_If_Flush()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Flush).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.Flush));
		}
	}
}
