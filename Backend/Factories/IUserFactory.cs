using Backend.Models.DTO_s;
using Backend.Models.Entities;

namespace Backend.Factories
{
    public interface IUserFactory
    {
        Task<CreateUserDto> CreateUser(string firstName, string lastName, string email, string password, string confirmPassword);
    }
}
