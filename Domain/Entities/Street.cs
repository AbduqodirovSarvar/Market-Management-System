using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Street : LocalizableEntity
    {
        public long DistrictId { get; set; }
        public District? District { get; set; }
    }
}
