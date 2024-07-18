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
                Id = Guid.Parse("ddcd0ddd-36bf-4d3a-93a0-0e736cdc77c2"),
                NameEn = "SuperAdmin",
                NameUz = "SuperAdmin",
                NameRu = "СуперАдмин",
                DescriptionEn = "Super administrator role with elevated permissions",
                DescriptionUz = "Oshiruvchi ruxsatga ega super administrator roli",
                DescriptionRu = "Роль супер администратора с расширенными правами"
            },
        new UserRole
            {
                Id = Guid.Parse("d3db861b-78c0-4da6-a10f-271921845dc9"),
                NameEn = "Admin",
                NameUz = "Admin",
                NameRu = "Админ",
                DescriptionEn = "Administrator role with full permissions",
                DescriptionUz = "To'liq ruxsatga ega administrator roli",
                DescriptionRu = "Роль администратора с полными правами"
            },
        ];
}
