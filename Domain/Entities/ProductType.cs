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
        public long MeasureId { get; set; }
        public MeasureOfType? MeasureOfType { get; set; }
    }
}
