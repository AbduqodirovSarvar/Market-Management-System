using Domain.Abstractions;
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
    public class UserTypeConfiguration : PersonBaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
            builder.HasOne(x => x.Organization).WithMany().HasForeignKey(x => x.OrganizationId);
        }
    }
}
