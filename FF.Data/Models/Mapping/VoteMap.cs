using System.Data.Entity.ModelConfiguration;

namespace FF.Data.Models.Mapping
{
    public class VoteMap : EntityTypeConfiguration<Vote>
    {
        public VoteMap()
        {
            // Primary Key
            this.HasKey(t => t.VoteId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Votes");
            this.Property(t => t.VoteId).HasColumnName("VoteId");
            this.Property(t => t.ReviewId).HasColumnName("ReviewId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UpVote).HasColumnName("UpVote");
            this.Property(t => t.AddedBy).HasColumnName("AddedBy");
            this.Property(t => t.AddedWhen).HasColumnName("AddedWhen");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedWhen).HasColumnName("UpdatedWhen");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.Review)
                .WithMany(t => t.Votes)
                .HasForeignKey(d => d.ReviewId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Votes)
                .HasForeignKey(d => d.UserId);

        }
    }
}
