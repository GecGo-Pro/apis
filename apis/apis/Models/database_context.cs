

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace apis.Models
{
    public class Database_context : DbContext
    {
        public Database_context(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Customer> customers { get; set; }
        public DbSet<Dispatcher> dispatchers { get; set; }
        public DbSet<Driver> drivers { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<Dispatch_job> dispatch_jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
