namespace FF.Data.Models
{
    public interface IUserLevel
    {

        int UserLevelId { get; set; }
        string Name { get; set; }
        int Rank { get; set; }
    }
}
