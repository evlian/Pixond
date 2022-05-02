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
            return await _context.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _context.Users.SingleOrDefaultAsync(e => e.UserId == userId);
        }

        public async Task<User> RegisterUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return _context.Users.FirstOrDefault(x => x.UserId == user.UserId);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            var result = await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
            return result != null;
        }
    }
}
