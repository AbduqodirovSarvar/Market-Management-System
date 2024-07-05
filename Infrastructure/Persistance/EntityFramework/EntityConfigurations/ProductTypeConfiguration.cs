using Domain.Entities;
using Infrastructure.Persistance.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.EntityFramework.EntityConfigurations
{
    public class ProductTypeConfiguration : DescriptionLocalizableEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => new { x.NameEn, x.ProductTypeId }).IsUnique();
            builder.HasIndex(x => new { x.NameUz, x.ProductTypeId }).IsUnique();
            builder.HasIndex(x => new { x.NameRu, x.ProductTypeId }).IsUnique();
        }
    }
}
