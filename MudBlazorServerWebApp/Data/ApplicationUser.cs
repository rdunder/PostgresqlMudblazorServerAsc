using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MudBlazorServerWebApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        public bool IsAdmin { get; set; }
    }

}
