using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.DefaultInformations;

public static class DefaultDistrictData
{
    public static readonly List<District> DefaultDistricts = [
        new District
        {
            RegionId = DefaultRegionData.DefaultRegions[0].Id,
            NameUz = "Chilonzor tumani",
            NameEn = "Chilonzor district",
            NameRu = "Чиланзарский район"
        },
        new District
        {
            RegionId = DefaultRegionData.DefaultRegions[0].Id,
            NameUz = "Yunusobod tumani",
            NameEn = "Yunusobod district",
            NameRu = "Юнусабадский район"
        },
        new District
        {
            RegionId = DefaultRegionData.DefaultRegions[0].Id,
            NameUz = "Shayxontohur tumani",
            NameEn = "Shayxontohur district",
            NameRu = "Шайхонтохурский район"
        },
        new District
        {
            RegionId = DefaultRegionData.DefaultRegions[0].Id,
            NameUz = "Yakkasaroy tumani",
            NameEn = "Yakkasaroy district",
            NameRu = "Яккасарайский район"
        },
        new District
        {
            RegionId = DefaultRegionData.DefaultRegions[0].Id,
            NameUz = "Uchtepa tumani",
            NameEn = "Uchtepa district",
            NameRu = "Учтепинский район"
        },
        new District
        {
            RegionId = DefaultRegionData.DefaultRegions[0].Id,
            NameUz = "Olmazor tumani",
            NameEn = "Olmazor district",
            NameRu = "Алмазарский район"
        },
        new District
        {
            RegionId = DefaultRegionData.DefaultRegions[0].Id,
            NameUz = "Mirzo Ulug'bek tumani",
            NameEn = "Mirzo Ulug'bek district",
            NameRu = "Мирзо-Улугбекский район"
        },
        new District
        {
            RegionId = DefaultRegionData.DefaultRegions[0].Id,
            NameUz = "Bektemir tumani",
            NameEn = "Bektemir district",
            NameRu = "Бектемирский район"
        },
        new District
        {
            RegionId = DefaultRegionData.DefaultRegions[0].Id,
            NameUz = "Mirobod tumani",
            NameEn = "Mirobod district",
            NameRu = "Мирабадский район"
        },
        new District
        {
            RegionId = DefaultRegionData.DefaultRegions[0].Id,
            NameUz = "Sergeli tumani",
            NameEn = "Sergeli district",
            NameRu = "Сергелийский район"
        },
        new District
        {
            RegionId = DefaultRegionData.DefaultRegions[0].Id,
            NameUz = "Yashnobod tumani",
            NameEn = "Yashnobod district",
            NameRu = "Яшнабадский район"
        }
    ];
}
