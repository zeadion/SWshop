using SWshop.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SWshop.Infra.Data.EntityConfig
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Price)
                .IsRequired();
        }
    }
}
