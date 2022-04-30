using Pixond.Core.Abstraction.Services.Users;
using Pixond.Core.Services.Genres;
using Pixond.Data;
using Pixond.Model.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pixond.Core.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly ILogger<GenresService> _logger;
        private readonly FilmLibraryContext _context;

        public UsersService(FilmLibraryContext context, ILogger<GenresService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<User> AuthenticateUser(User user)
        {
            User found = await _context.Users.Where(u => u.Username == user.Username).FirstOrDefaultAsync();
            if (found == null)
                return null;
            if (found.Password != user.Password)
                return null;
            return found;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(e => e.UserId == id);
        }

        public async Task<User> RegisterUser(User user)
        {
            user.CreatedAt = DateTime.Now;
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return await AuthenticateUser(user);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            var result = await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
            return result != null;
        }
    }
}
