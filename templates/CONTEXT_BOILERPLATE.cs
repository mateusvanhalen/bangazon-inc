using Microsoft.EntityFrameworkCore;
using OurApplication.Models;

namespace OurApplication.Data
{
    public class OurApplicationContext : DbContext
    {
        public OurApplicationContext(DbContextOptions<OurApplicationContext> options)
            : base(options)
        { }

        public DbSet<ApplicationType> ApplicationType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // If a model has a date field that should be generated by the database
            modelBuilder.Entity<ApplicationType>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");
        }
    }
}