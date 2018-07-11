using System.Data.Entity.Spatial;

namespace FF.Data.Models
{
    public interface ILocation
    {
        int LocationId { get; set; }

        string PlaceId { get; set; }
        string Name { get; set; }
        DbGeography Coordinates { get; set; }
        string Description { get; set; }
        bool IsPermanent { get; set; }
        int? AkaLocationId { get; set; }
    }
}
