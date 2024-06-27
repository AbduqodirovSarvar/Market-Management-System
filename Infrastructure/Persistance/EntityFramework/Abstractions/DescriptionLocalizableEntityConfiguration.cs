using Domain.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.EntityFramework.Abstractions
{
    public abstract class DescriptionLocalizableEntityConfiguration<TEntity> : LocalizableEntityConfiguration<TEntity> where TEntity : DescriptionLocalizableEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
