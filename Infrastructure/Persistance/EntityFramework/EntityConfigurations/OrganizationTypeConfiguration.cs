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
    public class OrganizationTypeConfiguration : DescriptionLocalizableEntityConfiguration<Organization>
    {
        public override void Configure(EntityTypeBuilder<Organization> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => new { x.AddressId, x.NameEn }).IsUnique();
            builder.HasIndex(x => new { x.AddressId, x.NameUz }).IsUnique();
            builder.HasIndex(x => new { x.AddressId, x.NameRu }).IsUnique();
            builder.HasOne(x => x.Address).WithMany().HasForeignKey(x => x.AddressId);
        }
    }
}
