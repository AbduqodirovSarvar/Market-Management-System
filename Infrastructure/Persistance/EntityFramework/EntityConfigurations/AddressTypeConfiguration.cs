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
    public class AddressTypeConfiguration : AudiTableEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => new { x.StreetId, x.Home }).IsUnique();
            builder.HasOne(x => x.Street).WithMany().HasForeignKey(x => x.StreetId);
        }
    }
}
