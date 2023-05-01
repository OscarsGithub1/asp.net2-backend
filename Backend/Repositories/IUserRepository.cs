    using Backend.Models.DTO_s;
    using Backend.Models.Entities;
    using global::Backend.Models.DTO_s;
    using global::Backend.Models.Entities;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Backend.Repositories
    {
        public interface IUserRepository
        {
            Task<IdentityResult> CreateUserAsync(CreateUserDto userDto, string password);
            Task<User> GetUserByIdAsync(int id);
            Task<User> GetUserByEmailAsync(string email);
            Task<IEnumerable<UserDto>> GetUsersAsync();
            Task<IdentityResult> UpdateUserAsync(User user, string password = null);
            Task<IdentityResult> DeleteUserAsync(User user);
        
        }
    }


