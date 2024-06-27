using Domain.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.EntityFramework.Abstractions
{
    public abstract class LocalizableEntityConfiguration<TEntity> : AudiTableEntityConfiguration<TEntity> where TEntity : LocalizableEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            builder.Property(a => a.NameRu).HasMaxLength(256);
            builder.Property(a => a.NameUz).HasMaxLength(256);
            builder.Property(a => a.NameEn).HasMaxLength(256);
            builder.HasIndex(x => new { x.NameRu, x.NameUz, x.NameEn }).IsUnique();
        }
    }
}
