using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Interfaces
{
    public interface IAudiTableEntity
    {
        Guid CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
