using Microsoft.EntityFrameworkCore;
using RywareParkingSystem.DAL.Entities;

namespace RywareParkingSystem.DAL.Context
{
    public class ParkingContext : DbContext
    {
        public DbSet<ParkingDatabaseModel>  Parkings { get; set; }
        public ParkingContext() 
        { }

        public ParkingContext(DbContextOptions<ParkingContext> options) 
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=parkingsdb;Username=postgres;Password=fadsfasd-xcvzxcv-321zxcfz-sd");
        }
    }
}
