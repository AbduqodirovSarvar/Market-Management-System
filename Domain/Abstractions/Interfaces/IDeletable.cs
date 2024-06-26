using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Interfaces
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedTime { get; set; }
    }
}
