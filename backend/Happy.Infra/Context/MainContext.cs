using Happy.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Happy.Infra.Context
{
    public class MainContext : IdentityDbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
          : base(options)
        {
        }

        public MainContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
        }

        public DbSet<Orphanage> Orphanages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("DefaultConnection");
            }
        }
    }
}