using System.Data.Entity.ModelConfiguration;

namespace FF.Data.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DisplayName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.HomeZipCode)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UserLevelId).HasColumnName("UserLevelId");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.DisplayName).HasColumnName("DisplayName");
            this.Property(t => t.HomeZipCode).HasColumnName("HomeZipCode");
            this.Property(t => t.HomeCoordinates).HasColumnName("HomeCoordinates");
            this.Property(t => t.AddedBy).HasColumnName("AddedBy");
            this.Property(t => t.AddedWhen).HasColumnName("AddedWhen");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedWhen).HasColumnName("UpdatedWhen");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.UserLevel)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.UserLevelId);

        }
    }
}
