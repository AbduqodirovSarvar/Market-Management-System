using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductType : DescriptionLocalizableEntity
    {
        public Guid MeasureOfTypeId { get; set; }
        public MeasureOfType? MeasureOfType { get; set; }
    }
}
