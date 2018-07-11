namespace FF.Data.Models
{
    public partial class Vote: UpdateableModel, IVote
    {

        public int VoteId { get; set; }
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public bool UpVote { get; set; }
 

        public virtual Review Review { get; set; }
        public virtual User User { get; set; }
    }
}
