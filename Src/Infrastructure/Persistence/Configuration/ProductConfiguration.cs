using Domain.Entities.ProductEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x=>x.PictureUrl).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.productBrand).WithMany().HasForeignKey(x => x.ProductBrandId);
            builder.HasOne(x => x.productType).WithMany().HasForeignKey(x => x.ProductTypeId);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.Title).HasMaxLength(300);
            builder.Property(x => x.Summary).HasMaxLength(2000);
            builder.HasKey(x => x.Id);


        }
    }
}
