using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.DefaultInformations;

public static class DefautUserData
{
    public static readonly User DefaultUser = new()
    {
        FirstName = "SuperAdmin",
        LastName = "SuperAdmin",
        Email = "superadmin@gmail.com",
        Phone = "+998987654321",
        Gender = Gender.None,
        RoleId = DefaultUserRoleData.DefaultUserRoles[0].Id,
        PasswordHash = "",
        OrganizationId = Guid.NewGuid(),
    };
}
