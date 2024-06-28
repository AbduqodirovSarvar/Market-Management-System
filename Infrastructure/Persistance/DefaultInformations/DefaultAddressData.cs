using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.DefaultInformations;

public static class DefaultAddressData
{
    public static readonly Address DefaultAddress = new()
    {
        StreetId = DefaultStreetData.DefaultStreets[0].Id,
        Home = "10",
        AddressLine = "QirqQiz 10"
    };
}
