using BeautyWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeautyWebAPI.Data
{
    public class BeautyStudioDbContext : DbContext
    {
        public BeautyStudioDbContext(DbContextOptions<BeautyStudioDbContext> options)
            :base(options)
        {
            
        }
        // Proprties:
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hairdresser> Hairdressers{ get; set; }

    }
}
