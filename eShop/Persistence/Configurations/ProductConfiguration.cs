using Domain.Products;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).HasConversion(
                productId => productId.Value,
                value => new ProductId(value));

            builder.Property(p => p.Sku).HasConversion(
              sku => sku.Value,
              value => Sku.Create(value)!);

            builder.OwnsOne(p => p.Price, priceBulder =>
            {
                priceBulder.Property(x => x.Currency).HasMaxLength(3);
            });


        }
    }
}
