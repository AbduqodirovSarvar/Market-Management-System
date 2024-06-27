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
    public class DistrictTypeConfiguration : LocalizableEntityConfiguration<District>
    {
        public override void Configure(EntityTypeBuilder<District> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => new { x.NameEn, x.NameUz, x.NameRu, x.RegionId }).IsUnique();
            builder.HasOne(x => x.Region).WithMany().HasForeignKey(x => x.RegionId);
        }
    }
}
