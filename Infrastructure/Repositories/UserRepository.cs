using Application.Exceptions.User;
using Application.UseCases.JwtService;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Authentication;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context, IJwtTokenGenerator tokenGenerator) : IUserRepository
    {
        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null) throw new UserNotFoundException(id);
            user.IsActive = false;
            await context.SaveChangesAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await context.Users.AnyAsync(u => u.Email == email && u.IsActive);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email && u.IsActive);
            
            if (user == null)
            {
                throw new UserNotFoundException(0);
            }

            if (user.Password != password)
            {
                throw new LoginUnauthorizedException();
            }
            var request = new JwtUserRequest
            {
                Id = user.Id,
                Name = user.Name,
                IsAdmin = user.IsAdmin,
            };

            return tokenGenerator.GenerateToken(request);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users
                .Where(u => u.IsActive)
                .ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await context.Users.Where(u => u.Id == id && u.IsActive).FirstOrDefaultAsync();
            if (user == null) throw new UserNotFoundException(id);
            return user;        
        }

        public async Task UpdateAsync(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
