using Application.Abstractions.Interfaces;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.EntityFramework
{
    public class AppDbContext(
        DbContextOptions<AppDbContext> options,
        ICurrentUserService currentUserService
        ) : DbContext(options), IAppDbContext
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
                    entry.Entity.Id = Guid.NewGuid();
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }
        }

        public async Task Seed()
        {

        }
    }
}
