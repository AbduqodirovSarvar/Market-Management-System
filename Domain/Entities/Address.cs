using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address : AudiTableEntity
    {
        public Guid StreetId { get; set; }
        public Street? Street { get; set; }
        public string Home { get; set; } = string.Empty;
        public string AddressLine { get; set; } = string.Empty;
    }
}
