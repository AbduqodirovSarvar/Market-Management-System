using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.DefaultInformations;

public static class DefaultUserRoleData
{
    public static readonly List<UserRole> DefaultUserRoles = [
        new UserRole
            {
                NameEn = "SuperAdmin",
                NameUz = "SuperAdmin",
                NameRu = "SuperAdmin",
                DescriptionEn = "Super administrator role with elevated permissions",
                DescriptionUz = "Oshiruvchi ruxsatga ega super administrator roli",
                DescriptionRu = "Роль супер администратора с расширенными правами"
            },
        new UserRole
            {
                NameEn = "Admin",
                NameUz = "Admin",
                NameRu = "Admin",
                DescriptionEn = "Administrator role with full permissions",
                DescriptionUz = "To'liq ruxsatga ega administrator roli",
                DescriptionRu = "Роль администратора с полными правами"
            },
        ];
}
