using System.Data.Entity.ModelConfiguration;

namespace FF.Data.Models.Mapping
{
    public class LocationMap : EntityTypeConfiguration<Location>
    {
        public LocationMap()
        {
            // Primary Key
            this.HasKey(t => t.LocationId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(150);

            this.Property(t => t.Description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Locations");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Coordinates).HasColumnName("Coordinates");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.IsPermanent).HasColumnName("IsPermanent");
            this.Property(t => t.AkaLocationId).HasColumnName("AkaLocationId");
            this.Property(t => t.AddedBy).HasColumnName("AddedBy");
            this.Property(t => t.AddedWhen).HasColumnName("AddedWhen");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedWhen).HasColumnName("UpdatedWhen");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasOptional(t => t.AkaLocation)
                .WithMany(t => t.AkaLocations)
                .HasForeignKey(d => d.AkaLocationId);

        }
    }
}
