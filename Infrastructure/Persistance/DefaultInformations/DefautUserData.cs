using Application.Abstractions.Interfaces;
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
    public static User DefaultUser { get; private set; } = null!;

    public static void Initialize(IHashService hashService)
    {
        DefaultUser = new User
        {
            FirstName = "SuperAdmin",
            LastName = "SuperAdmin",
            Email = "superadmin@gmail.com",
            Phone = "+998987654321",
            Gender = Gender.Male,
            RoleId = DefaultUserRoleData.DefaultUserRoles[0].Id,
            PasswordHash = hashService.GetHash("Admin123!@#"),
            OrganizationId = DefaultOrganizationData.DefaultOrganization.Id,
        };
    }
}
