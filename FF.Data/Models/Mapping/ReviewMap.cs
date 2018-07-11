using System.Data.Entity.ModelConfiguration;

namespace FF.Data.Models.Mapping
{
    public class ReviewMap : EntityTypeConfiguration<Review>
    {
        public ReviewMap()
        {
            // Primary Key
            this.HasKey(t => t.ReviewId);

            // Properties
            this.Property(t => t.Comment)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Reviews");
            this.Property(t => t.ReviewId).HasColumnName("ReviewId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.LocationId).HasColumnName("LocationId");
            this.Property(t => t.FruitId).HasColumnName("FruitId");
            this.Property(t => t.AquiredWhen).HasColumnName("AquiredWhen");
            this.Property(t => t.UserRating).HasColumnName("UserRating");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.RecordedWhen).HasColumnName("RecordedWhen");
            this.Property(t => t.FreshnessScore).HasColumnName("FreshnessScore");
            this.Property(t => t.VoteTally).HasColumnName("VoteTally");
            this.Property(t => t.AddedBy).HasColumnName("AddedBy");
            this.Property(t => t.AddedWhen).HasColumnName("AddedWhen");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedWhen).HasColumnName("UpdatedWhen");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.Fruit)
                .WithMany(t => t.Reviews)
                .HasForeignKey(d => d.FruitId);
            this.HasRequired(t => t.Location)
                .WithMany(t => t.Reviews)
                .HasForeignKey(d => d.LocationId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Reviews)
                .HasForeignKey(d => d.UserId);

        }
    }
}
