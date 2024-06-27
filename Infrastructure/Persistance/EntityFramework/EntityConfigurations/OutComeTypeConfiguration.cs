﻿using Domain.Entities;
using Infrastructure.Persistance.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.EntityFramework.EntityConfigurations
{
    public class OutComeTypeConfiguration : AudiTableEntityConfiguration<OutCome>
    {
        public override void Configure(EntityTypeBuilder<OutCome> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Organization).WithMany().HasForeignKey(x => x.OrganizationId);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
        }
    }
}
