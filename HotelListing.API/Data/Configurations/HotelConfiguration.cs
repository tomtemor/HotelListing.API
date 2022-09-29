using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
