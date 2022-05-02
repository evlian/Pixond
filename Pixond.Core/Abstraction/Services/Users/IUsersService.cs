using Pixond.Model.Entitites;
using System;
using System.Threading.Tasks;

namespace Pixond.Core.Abstraction.Services.Users
{
    public interface IUsersService
    {
        Task<User> RegisterUser(User user);
        Task<User> AuthenticateUser(User user);
        Task<User> GetUserById(Guid userId);
        Task<bool> IsUsernameTaken(string username);
    }
}
