using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.DefaultInformations;

public class DefaultCountryData
{
    public static readonly List<Country> DefaultCountries = [
            new Country { NameUz = "O'zbekiston", NameEn = "Uzbekistan", NameRu = "Узбекистан" },
            new Country { NameUz = "Qozog'iston", NameEn = "Kazakhstan", NameRu = "Казахстан" },
            new Country { NameUz = "Turkmaniston", NameEn = "Turkmenistan", NameRu = "Туркменистан" },
            new Country { NameUz = "Qirg'iziston", NameEn = "Kyrgyzstan", NameRu = "Киргизия" },
            new Country { NameUz = "Tojikiston", NameEn = "Tajikistan", NameRu = "Таджикистан" },
            new Country { NameUz = "Xitoy", NameEn = "China", NameRu = "Китай" },
            new Country { NameUz = "Hindiston", NameEn = "India", NameRu = "Индия" },
            new Country { NameUz = "Yaponiya", NameEn = "Japan", NameRu = "Япония" },
            new Country { NameUz = "Janubiy Koreya", NameEn = "South Korea", NameRu = "Южная Корея" },
            new Country { NameUz = "Vyetnam", NameEn = "Vietnam", NameRu = "Вьетнам" },
            new Country { NameUz = "Indoneziya", NameEn = "Indonesia", NameRu = "Индонезия" },
            new Country { NameUz = "Turkiya", NameEn = "Turkey", NameRu = "Турция" },
    ];
}
