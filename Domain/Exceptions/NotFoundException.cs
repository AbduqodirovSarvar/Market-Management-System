using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Entity was not found.") { }
        public NotFoundException(string message) : base(message) { }
    }
}
