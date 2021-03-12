using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Uppgift4;
using Uppgift4.Extensions;

namespace Uppgift4.Tests
{
    [TestClass]
    public class Deck_Shuffle
    {

		[TestMethod]
		public void Is_Statistically_Accurate()
		{
			/*		 
			 *		Number of possible 5-card poker hands:
			 *		(52 choose 5) = 52! / (5! * 47!) = 2 598 960
			 *		Let's shuffle 2.6 million times and count the given hands
			 */
			var poker = new PokerAnalyzer(new FakePokerHands(9).GetHand());
            for (int i = 0; i < 2598960; i++)
            {
				poker.DealNewHand();
				poker.CheckHand();
            }
			var num_of_two_pairs = poker.HandsDealt[(int)Pokerhands.TwoPair];
			var num_of_straights = poker.HandsDealt[(int)Pokerhands.Straight];
			/*
			 *		Statistically we should have:
			 *		-	123 552 counts of two pair hands ( 4.75 % of hands)
			 *		-	 10 200 counts of straight hands ( 0.39 % of hands)
			 *		Let's accept 5 % error
			 */
			var err = 0.05;
			Assert.IsTrue(num_of_two_pairs <= 123552 * (1 + err) && num_of_two_pairs >= 123552 * (1 - err));
			Assert.IsTrue(num_of_straights <= 10200 * (1 + err) && num_of_straights >= 10200 * (1 - err));

		}

	}
}
