using Backend.Models.Entities;

namespace Backend.Models.DTO_s
{

        public class CreateUserDto
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }
    
}
