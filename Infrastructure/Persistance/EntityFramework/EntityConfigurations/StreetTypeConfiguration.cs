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
    public class StreetTypeConfiguration : LocalizableEntityConfiguration<Street>
    {
        public override void Configure(EntityTypeBuilder<Street> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => new { x.NameUz, x.NameRu, x.NameEn, x.DistrictId }).IsUnique();
            builder.HasOne(x => x.District).WithMany().HasForeignKey(x => x.DistrictId);
        }
    }
}
