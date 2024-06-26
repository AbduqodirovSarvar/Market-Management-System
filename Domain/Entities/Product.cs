using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : DescriptionLocalizableEntity
    {
        public long ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }
        public string? ImageName { get; set; }
    }
}
