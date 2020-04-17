using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DALInvemtory.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Productid);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(50);

            this.Property(t => t.photo)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Product");
            this.Property(t => t.Productid).HasColumnName("Productid");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.photo).HasColumnName("photo");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.lastupdated).HasColumnName("lastupdated");
        }
    }
}
