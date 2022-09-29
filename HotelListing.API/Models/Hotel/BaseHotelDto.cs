using Microsoft.Build.Framework;

namespace HotelListing.API.Models.Hotel
{
    public abstract class BaseHotelDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        public double? Rating { get; set; }
        public int CountryId { get; set; }
    }
}
