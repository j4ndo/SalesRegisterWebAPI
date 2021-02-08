using Microsoft.EntityFrameworkCore;
using SalesRegisterWebAPI.Domain.Models;

namespace SalesRegisterWebAPI.Infra.Contexts
{
    public class SalesRegisterContext : DbContext
    {
        public SalesRegisterContext(DbContextOptions<SalesRegisterContext> options)
            : base(options)
        {
        }

        public DbSet<SalesRegister> SalesRegisters { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        
    }
}