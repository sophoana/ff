using System;
using System.Collections.Generic;

namespace FF.Data.Models
{
    public partial class Review : UpdateableModel, IReview
    {
        public Review()
        {
            Votes = new List<Vote>();
        }

        public double CalculateFreshnessScore(int votes)
        {
            //HN decay algorithm http://osmy.in/1Wk14xk
            var daysSinceReview = (base.DateTimeService.UtcNow() - UpdatedWhen).Days;
            var numerator = (double)(votes - 1); //minus their own vote
            var denominator = Math.Pow((double)(daysSinceReview + 2.0), Gravity);
            return numerator / denominator;
        }

        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public int FruitId { get; set; }
        public DateTime AquiredWhen { get; set; }
        public int UserRating { get; set; }
        public string Comment { get; set; }
        public byte[] Image { get; set; }
        public DateTime RecordedWhen { get; set; }
        public double FreshnessScore { get; set; }
        public int VoteTally { get; set; }

        public virtual Fruit Fruit { get; set; }
        public virtual Location Location { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }


        private const double Gravity = 1.8;

    }
}
