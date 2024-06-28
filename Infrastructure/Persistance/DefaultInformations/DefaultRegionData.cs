using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.DefaultInformations;

public static class DefaultRegionData
{
    public static readonly List<Region> DefaultRegions = [
        new Region { NameUz = "Toshkent-shahar", NameEn = "Tashkent-city", NameRu = "Ташкент-город", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Toshkent", NameEn = "Tashkent", NameRu = "Ташкент", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Samarqand", NameEn = "Samarkand", NameRu = "Самарканд", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Buxoro", NameEn = "Bukhara", NameRu = "Бухара", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Xorazm", NameEn = "Khorezm", NameRu = "Хорезм", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Farg'ona", NameEn = "Fergana", NameRu = "Фергана", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Andijon", NameEn = "Andijan", NameRu = "Андижан", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Namangan", NameEn = "Namangan", NameRu = "Наманган", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Qashqadaryo", NameEn = "Kashkadarya", NameRu = "Кашкадарья", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Surxondaryo", NameEn = "Surkhandarya", NameRu = "Сурхандарья", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Jizzax", NameEn = "Jizzakh", NameRu = "Джизак", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Sirdaryo", NameEn = "Syrdarya", NameRu = "Сырдарья", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Navoiy", NameEn = "Navoi", NameRu = "Навои", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Qoraqalpog'iston", NameEn = "Karakalpakstan", NameRu = "Каракалпакстан", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Termiz", NameEn = "Termez", NameRu = "Термез", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Marg'ilon", NameEn = "Margilan", NameRu = "Маргилан", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Nukus", NameEn = "Nukus", NameRu = "Нукус", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Urganch", NameEn = "Urgench", NameRu = "Ургенч", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Guliston", NameEn = "Gulistan", NameRu = "Гулистан", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Qarshi", NameEn = "Karshi", NameRu = "Карши", CountryId = DefaultCountryData.DefaultCountries[0].Id },
        new Region { NameUz = "Angren", NameEn = "Angren", NameRu = "Ангрен", CountryId = DefaultCountryData.DefaultCountries[0].Id }

    ];
}
