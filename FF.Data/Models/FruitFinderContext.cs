using System.Data.Entity;
using System.Linq;
using FF.Data.Models.Mapping;

namespace FF.Data.Models
{
    public partial class FruitFinderContext : DbContext, IFruitFinderContext
    {
        public FruitFinderContext()
            : base("Name=FruitFinderContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer<FruitFinderContext>(null);
        }

        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<FruitVariety> FruitVarieties { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserLevel> UserLevels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FruitMap());
            modelBuilder.Configurations.Add(new FruitVarietyMap());
            modelBuilder.Configurations.Add(new LocationMap());
            modelBuilder.Configurations.Add(new ReviewMap());
            modelBuilder.Configurations.Add(new UserLevelMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new VoteMap());

            base.OnModelCreating(modelBuilder);
        }

        public void SetAddedOrModified(object entity, int id)
        {
            Entry(entity).State =
                id == 0 ?
                EntityState.Added :
                EntityState.Modified;
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            //Reset read-only entities so they aren't changed in the database
            foreach (var item in modified)
            {
                if (item.Entity is ReadOnlyModel)
                {
                    item.State = EntityState.Unchanged;
                }
                else if (item.Entity is UpdateableModel)
                {
                    if (item.State == EntityState.Modified)
                    {
                        var updateableModel = ((UpdateableModel)item.Entity);
                        Entry(updateableModel).Property("AddedBy").IsModified = false;   
                        Entry(updateableModel).Property("AddedWhen").IsModified = false;
                    }
                }
            }

            return base.SaveChanges();
        }

    }
}
