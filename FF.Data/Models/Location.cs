using System.Collections.Generic;
using System.Data.Entity.Spatial;

namespace FF.Data.Models
{
    public partial class Location : UpdateableModel, ILocation
    {
        public Location()
        {
            this.AkaLocations = new List<Location>();
            this.Reviews = new List<Review>();
        }

        public int LocationId { get; set; }

        public string PlaceId { get; set; }
        public string Name { get; set; }
        public DbGeography Coordinates { get; set; }
        public string Description { get; set; }
        public bool IsPermanent { get; set; }
        public int? AkaLocationId { get; set; }

        public virtual ICollection<Location> AkaLocations { get; set; }
        public virtual Location AkaLocation { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
