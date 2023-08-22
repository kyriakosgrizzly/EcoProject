using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelsF.Models;
using MVCAnri.Models;

namespace MVCAnri.Controllers.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule
                {
                    Id = 1,
                    Name = "School",
                    Date = DateTime.Now.AddHours(3)
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Title = "The Idiot",
                ISBN = "KEKW#",
                Author = "Dostoevsky",
                Description = "Description",
                ListPrice = 25,
                Price = 23,
                Price50 = 22,
                Price100 = 20,
                CategoryId = 1,
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                DisplayOrder = 1,
                Name = "Sci-fi"
            }, new Category
            {
                Id = 2,
                DisplayOrder = 2,
                Name = "Fantasy"
            },new Category
            {
                Id = 3,
                DisplayOrder = 3,
                Name = "Mystery"
            });
        }
    }

}
