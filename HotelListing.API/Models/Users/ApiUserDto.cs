using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace HotelListing.API.Models.Users;

public class ApiUserDto : LoginDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
       
  
}
