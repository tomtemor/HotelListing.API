using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }


        /// <summary>
        /// Seeding data in DbContext using OnModelCreating
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name ="Sweden",
                    ShortName = "SE"
                },
                 new Country
                 {
                     Id = 2,
                     Name = "Norway",
                     ShortName = "NO"
                 },
                  new Country
                  {
                      Id = 3,
                      Name = "Denmark",
                      ShortName = "DK"
                  }

                );
            modelBuilder.Entity<Hotel>().HasData(
               new Hotel
               {
                   Id = 1,
                   Name = "Hilton",
                   Address = "Gatan 3",
                   CountryId = 1,
                   Rating = 3

               },
                new Hotel
                {
                    Id = 2,
                    Name = "Sheraton",
                    Address = "Gatan 4",
                    CountryId = 2,
                    Rating = 3
                },
                 new Hotel
                 {
                     Id = 3,
                     Name = "GB Glass",
                     Address = "Gatan 4",
                     CountryId = 3,
                     Rating = 3
                 }

               );
        }
    }
}
