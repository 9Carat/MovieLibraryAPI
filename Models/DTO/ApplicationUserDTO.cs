using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MovieLibraryAPI.Models.DTO
{
    public class ApplicationUserDTO :IdentityUser
    {
        public string Fk_UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
