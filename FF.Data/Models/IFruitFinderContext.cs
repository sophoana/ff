using System.Data.Entity;

namespace FF.Data.Models
{
    public interface IFruitFinderContext
    {
        DbSet<Fruit> Fruits { get; set; }
        DbSet<FruitVariety> FruitVarieties { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<UserLevel> UserLevels { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Vote> Votes { get; set; }

        int SaveChanges();

        void Dispose();

        void SetAddedOrModified(object entity, int id);
    }
}
