using System;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift4.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<int> Duplicates(this IEnumerable<int> sequence)
        {
            return sequence.GroupBy(x => x)
                           .Where(g => g.Count() == 2)
                           .Select(g => g.Key);
        }
        public static List<int> Ordered(this IEnumerable<int> sequence)
        {
            return sequence.OrderBy(x => x)
                           .ToList();
        }
		public static IEnumerable<int> Triplets(this IEnumerable<int> sequence)
		{
			return sequence.GroupBy(x => x)
							.Where(g => g.Count() == 3)
							.Select(g => g.Key);

		}
		public static IEnumerable<int> Quadruplets(this IEnumerable<int> sequence)
		{
			return sequence.GroupBy(x => x)
						   .Where(g => g.Count() == 4)
						   .Select(g => g.Key);

		}
		public static bool IsFlush(this List<string> sequence)
        {
			var isFlush = false;
			if (sequence.Distinct().Count() == 1)
			{
				isFlush = true;
			}
			return isFlush;
		}
        public static bool IsStraight(this IEnumerable<int> sequence)
        {
			var isStraight = false;
			var ordered = sequence.Ordered();
			if (ordered.Any(value => value == 1))
			{
				// There's an ace in hand
				ordered.Add(14);
			}
			int cards_in_series = 0;
			int temp = 1;
			for (int i = 1; i < ordered.Count; i++)
			{
				if (ordered[i] - ordered[i - 1] == 1)
				{
					temp++;
					if (temp > cards_in_series)
					{
						cards_in_series = temp;
					}
				}
				else
				{
					temp = 1;
				}
			}
			if (cards_in_series == 5)
			{
				isStraight = true;
			}
			return isStraight;
		}
    }
}
