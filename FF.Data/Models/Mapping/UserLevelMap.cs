using System.Data.Entity.ModelConfiguration;

namespace FF.Data.Models.Mapping
{
    public class UserLevelMap : EntityTypeConfiguration<UserLevel>
    {
        public UserLevelMap()
        {
            // Primary Key
            this.HasKey(t => t.UserLevelId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UserLevels");
            this.Property(t => t.UserLevelId).HasColumnName("UserLevelId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Rank).HasColumnName("Rank");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
