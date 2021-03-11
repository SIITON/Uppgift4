using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Uppgift4;
using Uppgift4.Extensions;

namespace Uppgift4.Tests
{
    [TestClass]
    public class Hand_Can
    {
		public List<int> Values { get; set; }
		public List<string> Faces { get; set; }
		[TestMethod]
		public void Analyze_rank_1_Pair()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Pair).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.Pair));
		}
		[TestMethod]
		public void Analyze_rank_1_No_Pair()
        {
			Hand hand = new FakePokerHands((int)Pokerhands.RoyalFlush).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.Pair));
		}
		[TestMethod]
		public void Analyze_rank_2_Two_Pair()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.TwoPair).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.TwoPair));
		}
		[TestMethod]
		public void Analyze_rank_2_No_Two_Pair()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Pair).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.TwoPair));
		}
		[TestMethod]
		public void Analyze_rank_3_Three_Of_A_Kind()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.ThreeOfAKind).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.ThreeOfAKind));
		}
		[TestMethod]
		public void Analyze_rank_3_No_Three_Of_A_Kind()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.TwoPair).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.ThreeOfAKind));
		}
		[TestMethod]
		public void Analyze_rank_4_Straight()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Straight).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.Straight));
		}
		[TestMethod]
		public void Analyze_rank_4_No_Straight()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Flush).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.Straight));
		}
		[TestMethod]
		public void Analyze_rank_4_Straight_With_Ace()
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
		public void Analyze_rank_5_Flush()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Flush).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.Flush));
		}
		[TestMethod]
		public void Analyze_rank_5_No_Flush()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.Straight).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.Flush));
		}
		[TestMethod]
		public void Analyze_rank_6_Full_House()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.FullHouse).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.FullHouse));
		}
		[TestMethod]
		public void Analyze_rank_6_No_Full_House()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.ThreeOfAKind).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.FullHouse));
		}
		[TestMethod]
		public void Analyze_rank_7_Four_Of_A_Kind()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.FourOfAKind).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.FourOfAKind));
		}
		[TestMethod]
		public void Analyze_rank_7_No_Four_Of_A_Kind()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.ThreeOfAKind).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.FourOfAKind));
		}
		[TestMethod]
		public void Analyze_rank_8_Straight_Flush()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.StraightFlush).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.StraightFlush));
		}
		[TestMethod]
		public void Analyze_rank_8_No_Straight_Flush()
		{
			Hand hand1 = new FakePokerHands((int)Pokerhands.Straight).GetHand();
			Hand hand2 = new FakePokerHands((int)Pokerhands.Flush).GetHand();

			Assert.IsFalse(hand1.RankOfHand.Contains((int)Pokerhands.StraightFlush));
			Assert.IsFalse(hand2.RankOfHand.Contains((int)Pokerhands.StraightFlush));
		}
		[TestMethod]
		public void Analyze_rank_9_Royal_Flush()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.RoyalFlush).GetHand();

			Assert.IsTrue(hand.RankOfHand.Contains((int)Pokerhands.RoyalFlush));
		}
		[TestMethod]
		public void Analyze_rank_9_No_Royal_Flush()
		{
			Hand hand = new FakePokerHands((int)Pokerhands.StraightFlush).GetHand();

			Assert.IsFalse(hand.RankOfHand.Contains((int)Pokerhands.RoyalFlush));
		}
	}
}
