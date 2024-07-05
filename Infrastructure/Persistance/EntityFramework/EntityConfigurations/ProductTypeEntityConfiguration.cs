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
    public class ProductTypeEntityConfiguration : DescriptionLocalizableEntityConfiguration<ProductType>
    {
        public override void Configure(EntityTypeBuilder<ProductType> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => new { x.NameRu, x.MeasureOfTypeId }).IsUnique();
            builder.HasIndex(x => new { x.NameUz, x.MeasureOfTypeId }).IsUnique();
            builder.HasIndex(x => new { x.NameEn, x.MeasureOfTypeId }).IsUnique();
            builder.HasOne(x => x.MeasureOfType).WithMany().HasForeignKey(x => x.MeasureOfTypeId);
        }
    }
}
