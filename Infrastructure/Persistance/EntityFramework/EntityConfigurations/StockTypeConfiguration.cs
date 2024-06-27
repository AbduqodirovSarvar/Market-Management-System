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
    public class StockTypeConfiguration : AudiTableEntityConfiguration<Stock>
    {
        public override void Configure(EntityTypeBuilder<Stock> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => new { x.ProductId, x.OrganizationId }).IsUnique();
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x =>x.ProductId);
            builder.HasOne(x => x.Organization).WithMany().HasForeignKey(x => x.OrganizationId);
        }
    }
}
