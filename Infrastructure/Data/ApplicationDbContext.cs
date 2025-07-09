using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Khach San 5 Sao",
                    Description = "vip pro",
                    ImageUrl = "https://d2e5ushqwiltxm.cloudfront.net/wp-content/uploads/sites/48/2024/07/05063252/PVD_DJI_0519_FULLSIZE-TIFF-AdobeRGB-17.jpg",
                    Occupancy = 20,
                    Price = 1000,
                    SquareMeter = 1000,
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Khach San 5 Sao",
                    Description = "vip pro",
                    ImageUrl = "https://d2e5ushqwiltxm.cloudfront.net/wp-content/uploads/sites/48/2024/07/05063252/PVD_DJI_0519_FULLSIZE-TIFF-AdobeRGB-17.jpg",
                    Occupancy = 20,
                    Price = 1000,
                    SquareMeter = 1000,
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Khach San 5 Sao",
                    Description = "vip pro",
                    ImageUrl = "https://d2e5ushqwiltxm.cloudfront.net/wp-content/uploads/sites/48/2024/07/05063252/PVD_DJI_0519_FULLSIZE-TIFF-AdobeRGB-17.jpg",
                    Occupancy = 20,
                    Price = 1000,
                    SquareMeter = 1000,
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Khach San 5 Sao",
                    Description = "vip pro",
                    ImageUrl = "https://d2e5ushqwiltxm.cloudfront.net/wp-content/uploads/sites/48/2024/07/05063252/PVD_DJI_0519_FULLSIZE-TIFF-AdobeRGB-17.jpg",
                    Occupancy = 20,
                    Price = 1000,
                    SquareMeter = 1000,
                }
            );
        }
    }
}
