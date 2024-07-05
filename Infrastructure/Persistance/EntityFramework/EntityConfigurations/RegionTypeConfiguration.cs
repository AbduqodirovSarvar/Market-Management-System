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
    public class RegionTypeConfiguration : LocalizableEntityConfiguration<Region>
    {
        public override void Configure(EntityTypeBuilder<Region> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => new { x.NameEn, x.CountryId }).IsUnique();
            builder.HasIndex(x => new { x.NameRu, x.CountryId}).IsUnique();
            builder.HasIndex(x => new { x.NameUz, x.CountryId }).IsUnique();
            builder.HasOne(x => x.Country).WithMany().HasForeignKey(x => x.CountryId);
        }
    }
}
