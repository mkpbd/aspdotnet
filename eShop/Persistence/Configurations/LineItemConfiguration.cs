using Domain.Orders;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(li => li.Id)
                .HasConversion(
                lineitem => lineitem.Value,
                value => new LineItemId(value));

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(li => li.ProductId);

            builder.OwnsOne(li => li.Price);
        }
    }
}
