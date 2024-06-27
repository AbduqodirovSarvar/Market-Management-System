using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : PersonBaseEntity
    {
        public string PasswordHash { get; set; } = null!;
        public Guid RoleId { get; set; }
        public UserRole? Role { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization? Organization { get; set; }
    }
}
