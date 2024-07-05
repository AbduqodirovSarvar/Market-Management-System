using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<District> Districts { get; set; }
        DbSet<InCome> Incomes { get; set; }
        DbSet<OutCome> Outcomes { get; set; }
        DbSet<Organization> Organizations { get; set; }
        DbSet<MeasureOfType> MeasureOfTypes { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<ProductPrice> Prices { get; set; }
        DbSet<Street> Streets { get; set; }
        DbSet<UserRole> Roles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
