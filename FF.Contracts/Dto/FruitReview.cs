using System;

namespace FF.Contracts.Dto
{
    public class FruitReview
    {
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
    }
}
