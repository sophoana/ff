namespace FF.Data.Models
{
    public interface IVote
    {
        int VoteId { get; set; }
        int ReviewId { get; set; }
        int UserId { get; set; }
        bool UpVote { get; set; }

    }
}
