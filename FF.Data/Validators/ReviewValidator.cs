using FF.Data.Models;
using System.Collections.Generic;

namespace FF.Data.Validators
{
    public class ReviewValidator
    {
        public static IList<string> GetValidationIssues(Review review)
        {
            var results = new List<string>();

            if (review == null)
            {
                results.Add("Review cannot be null");
                return results;
            }

            if (review.AddedBy == 0
                || review.UpdatedBy == 0)
            {
                results.Add("Review must have its audit fields set before validation");
            }

            if (review.FruitId == 0)
            {
                results.Add("Review must have a fruit associated with it.");
            }

            if (review.AddedWhen > review.UpdatedWhen)
            {
                results.Add("Review AddedWhen must not be after updated.");
            }

            return results;
        }
    }
}
