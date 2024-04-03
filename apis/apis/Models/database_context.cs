using Microsoft.EntityFrameworkCore;

namespace apis.Models
{
    public class database_context : DbContext
    {
        public database_context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<customer> customers { get; set; }
        public DbSet<dispatcher> dispatchers { get; set; }
        public DbSet<driver> drivers { get; set; }
        public DbSet<car> cars { get; set; }
        public DbSet<dispatch_job> dispatch_Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
