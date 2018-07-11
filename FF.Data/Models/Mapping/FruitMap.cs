using System.Data.Entity.ModelConfiguration;

namespace FF.Data.Models.Mapping
{
    public class FruitMap : EntityTypeConfiguration<Fruit>
    {
        public FruitMap()
        {
            // Primary Key
            this.HasKey(t => t.FruitId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Summary)
                .HasMaxLength(500);

            this.Property(t => t.WikiLink)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Fruits");
            this.Property(t => t.FruitId).HasColumnName("FruitId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.WikiLink).HasColumnName("WikiLink");
            this.Property(t => t.StockImage).HasColumnName("StockImage");
            this.Property(t => t.AddedBy).HasColumnName("AddedBy");
            this.Property(t => t.AddedWhen).HasColumnName("AddedWhen");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedWhen).HasColumnName("UpdatedWhen");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
