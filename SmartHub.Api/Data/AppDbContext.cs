using Microsoft.EntityFrameworkCore;
using SmartHub.Core.Models;
using System.Reflection;

namespace SmartHub.Api.Data.Mappings
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Declaration> Declarations { get; set; } = null!;
        public DbSet<Slip> Slips { get; set; } = null!;
        public DbSet<Association> Associations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
