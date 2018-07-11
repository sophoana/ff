using System.Data.Entity.Spatial;

namespace FF.Data.Models
{
    public interface IUser 
    {

        int UserId { get; set; }
        int UserLevelId { get; set; }
        string Username { get; set; }
        string DisplayName { get; set; }
        string HomeZipCode { get; set; }
        DbGeography HomeCoordinates { get; set; }
    }
}
