

using apis.SeedData;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace apis.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Customer> customers { get; set; }
        public DbSet<Dispatcher> dispatchers { get; set; }
        public DbSet<Driver> drivers { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<DispatchJob> dispatch_jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(CustomerSeedData.CustomerData());
            modelBuilder.Entity<Dispatcher>().HasData(DispatcherSeedData.DispatcherData());
            modelBuilder.Entity<Driver>().HasData(DriverSeedData.DriverData());
            modelBuilder.Entity<Car>().HasData(CarSeedData.CarData());
            modelBuilder.Entity<DispatchJob>().HasData(DispatchJobSeedData.DispatcherData());
            
        }
    }
}
