using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using ProFinder.Core.Entities;

namespace ProFinder.Core.Extensions
{
    public static class AppExtensions
    {
        public static double WeightedAverage<T>(this IEnumerable<T> reviews) where T : Review
        {
            var reviewsGrouped = reviews.GroupBy(c => c.Rating).ToDictionary(r => r.Key, p => p.Count());
            var numerator = reviewsGrouped.Sum(v => v.Key * v.Value);
            var denominator = reviewsGrouped.Sum(v => v.Value);
            if (denominator == 0)
                return 0;

            return numerator / denominator;
        }
    }
}
