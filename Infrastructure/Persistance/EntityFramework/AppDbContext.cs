using Application.Abstractions.Interfaces;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.EntityFramework
{
    public class AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService) : DbContext(options), IAppDbContext
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<InCome> Incomes { get; set; }
        public DbSet<OutCome> Outcomes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<MeasureOfType> MeasureOfTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<UserRole> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditableEntity();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditableEntity()
        {
            foreach (var entry in ChangeTracker.Entries<AudiTableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    //entry.Entity.Id = Guid.NewGuid();
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }
        }

        public async Task SeedAsync()
        {
            using var _context = this.GetService<AppDbContext>();

            try
            {
                _context.MeasureOfTypes.AddRange(DefaultInformations.DefaultMeasureOfTypeData.DefaultMeasureOfTypes);
                _context.Countries.AddRange(DefaultInformations.DefaultCountryData.DefaultCountries);
                _context.Roles.AddRange(DefaultInformations.DefaultUserRoleData.DefaultUserRoles);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error seeding initial data: {ex}");
            }

            try
            {
                _context.Regions.AddRange(DefaultInformations.DefaultRegionData.DefaultRegions);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error seeding additional data: {ex}");
            }

            try
            {
                _context.Districts.AddRange(DefaultInformations.DefaultDistrictData.DefaultDistricts);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            try
            {
                _context.Streets.AddRange(DefaultInformations.DefaultStreetData.DefaultStreets);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            try
            {
                _context.Addresses.Add(DefaultInformations.DefaultAddressData.DefaultAddress);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            try
            {
                _context.Organizations.Add(DefaultInformations.DefaultOrganizationData.DefaultOrganization);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            try
            {
                _context.Users.Add(DefaultInformations.DefautUserData.DefaultUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
