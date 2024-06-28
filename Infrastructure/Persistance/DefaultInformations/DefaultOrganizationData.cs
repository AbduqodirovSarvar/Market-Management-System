using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.DefaultInformations;

public class DefaultOrganizationData
{
    public static readonly Organization DefaultOrganization = new()
    {
        AddressId = DefaultAddressData.DefaultAddress.Id,
        NameEn = "BePro-DEVHUB",
        NameRu = "БеПро-ДЕВХУБ",
        NameUz = "BePro-DEVHUB",
        DescriptionEn = "BePro-DEVHUB is a leading software development hub focused on innovative solutions and professional growth.",
        DescriptionRu = "BePro-DEVHUB является ведущим центром разработки программного обеспечения, ориентированным на инновационные решения и профессиональный рост.",
        DescriptionUz = "BePro-DEVHUB - bu innovatsion yechimlar va professional o'sishga qaratilgan yetakchi dasturiy ta'minot ishlab chiqarish markazi."
    };
}
