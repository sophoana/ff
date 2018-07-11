using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace FF.Data.Models
{
    public partial class User : UpdateableModel, IUser
    {
        public User()
        {
            this.Reviews = new List<Review>();
            this.Votes = new List<Vote>();
        }

        public int UserId { get; set; }
        public int UserLevelId { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string HomeZipCode { get; set; }
        public DbGeography HomeCoordinates { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual UserLevel UserLevel { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
