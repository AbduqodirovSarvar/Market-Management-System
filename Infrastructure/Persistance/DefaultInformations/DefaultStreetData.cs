using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.DefaultInformations;

public class DefaultStreetData
{
    public static readonly List<Street> DefaultStreets = [
        new Street
        {
            DistrictId = DefaultDistrictData.DefaultDistricts[0].Id,
            NameUz = "Qirq qiz ko'chasi",
            NameEn = "Qirq qiz street",
            NameRu = "Кырк кизская улица"
        },
        new Street
        {
            DistrictId = DefaultDistrictData.DefaultDistricts[0].Id,
            NameUz = "Chilonzor ko'chasi",
            NameEn = "Chilonzor street",
            NameRu = "Чиланзарская улица"
        },
        new Street
        {
            DistrictId = DefaultDistrictData.DefaultDistricts[0].Id,
            NameUz = "Bunyodkor ko'chasi",
            NameEn = "Bunyodkor street",
            NameRu = "Бунёдкорская улица"
        },
        new Street
        {
            DistrictId = DefaultDistrictData.DefaultDistricts[0].Id,
            NameUz = "Qatortol ko'chasi",
            NameEn = "Qatortol street",
            NameRu = "Катартольская улица"
        },
        new Street
        {
            DistrictId = DefaultDistrictData.DefaultDistricts[0].Id,
            NameUz = "Yangihayot ko'chasi",
            NameEn = "Yangihayot street",
            NameRu = "Янгихаётская улица"
        },
        new Street
        {
            DistrictId = DefaultDistrictData.DefaultDistricts[0].Id,
            NameUz = "Farobiy ko'chasi",
            NameEn = "Farobiy street",
            NameRu = "Фарабийская улица"
        },
        new Street
        {
            DistrictId = DefaultDistrictData.DefaultDistricts[0].Id,
            NameUz = "Tinchlik ko'chasi",
            NameEn = "Tinchlik street",
            NameRu = "Тынчлыкская улица"
        },
        new Street
        {
            DistrictId = DefaultDistrictData.DefaultDistricts[0].Id,
            NameUz = "Guliston ko'chasi",
            NameEn = "Guliston street",
            NameRu = "Гулистанская улица"
        },
        new Street
        {
            DistrictId = DefaultDistrictData.DefaultDistricts[0].Id,
            NameUz = "Bog'ishamol ko'chasi",
            NameEn = "Bog'ishamol street",
            NameRu = "Богишамолская улица"
        },
        new Street
        {
            DistrictId = DefaultDistrictData.DefaultDistricts[0].Id,
            NameUz = "Yangiobod ko'chasi",
            NameEn = "Yangiobod street",
            NameRu = "Янгиободская улица"
        }
    ];
}