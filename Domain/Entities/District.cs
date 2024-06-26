using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class District : LocalizableEntity
    {
        public long RegionId { get; set; }
        public Region? Region { get; set; }
    }
}
