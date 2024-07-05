using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductPrice : AudiTableEntity
    {
        public Guid OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Price { get; set; }
    }
}
