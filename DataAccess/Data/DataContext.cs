using Microsoft.EntityFrameworkCore;
using MVCAnri.Models;

namespace MVCAnri.Controllers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Schedule> schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule
                {
                    Id = 1,
                    Name = "School",
                    Date = DateTime.Now.AddHours(3)
                }
            );
        }
    }

}
