using System;

namespace FF.Data.Models
{
    public interface IReview
    {

        double CalculateFreshnessScore(int votes);

        int ReviewId { get; set; }
        int UserId { get; set; }
        int LocationId { get; set; }
        int FruitId { get; set; }
        DateTime AquiredWhen { get; set; }
        int UserRating { get; set; }
        string Comment { get; set; }
        byte[] Image { get; set; }
        DateTime RecordedWhen { get; set; }
        double FreshnessScore { get; set; }
        int VoteTally { get; set; }
        int AddedBy { get; set; }
        DateTime AddedWhen { get; set; }
        int UpdatedBy { get; set; }
        DateTime UpdatedWhen { get; set; }

    }
}
