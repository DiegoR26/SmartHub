using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartHub.Api.Models;
using SmartHub.Core.Models;
using System.Reflection;

namespace SmartHub.Api.Data.Mappings
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
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
