using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Organization : DescriptionLocalizableEntity
    {
        public long AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
