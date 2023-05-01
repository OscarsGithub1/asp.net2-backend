using Microsoft.AspNetCore.Identity;

namespace Backend.Models.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string confirmPassword { get; set; }
        public string Description { get; set; }
        public bool forgotpassword { get; set; }
        public bool remeberme { get; set; }

    }
}
