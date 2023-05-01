using System;
using System.Threading.Tasks;
using Backend.Models.DTO_s;
using Backend.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Backend.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly UserManager<User> _userManager;

        public UserFactory(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserDto> CreateUser(string firstName, string lastName, string email, string password, string confirmPassword)
        {
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception("Failed to create user: " + string.Join(",", result.Errors));
            }

            var createUserDto = new CreateUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return createUserDto;
        }
    }
}








