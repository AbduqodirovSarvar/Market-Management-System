using Domain.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.EntityFramework.Abstractions
{
    public class PersonBaseEntityConfiguration<TEntity> : AudiTableEntityConfiguration<TEntity> where TEntity : PersonBaseEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x => x.Phone).IsUnique();
        }
    }
}
