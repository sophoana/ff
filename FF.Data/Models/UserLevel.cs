using System.Collections.Generic;

namespace FF.Data.Models
{
    public partial class UserLevel : ReadOnlyModel, IUserLevel
    {
        public UserLevel()
        {
            Users = new List<User>();
        }

        public int UserLevelId { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
