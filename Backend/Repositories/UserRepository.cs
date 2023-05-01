using Backend.Models.DTO_s;
using Backend.Models.Entities;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Entities;
using Backend.Models.DTO_s;
using Microsoft.EntityFrameworkCore;


    
namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityContext _dbContext;

        public UserRepository(IdentityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                UserName = createUserDto.Email
            };

            var result = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await GetUserByIdAsync(userId);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}

  
