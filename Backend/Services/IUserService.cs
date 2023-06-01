using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models.DTO_s;

namespace Backend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task CreateUserAsync(CreateUserDto userDto);
        Task UpdateUserAsync(int id, UserDto userDto);
        Task DeleteUserAsync(int id);
    }
}