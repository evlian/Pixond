using Pixond.Model.Entitites;
using System.Threading.Tasks;

namespace Pixond.Core.Abstraction.Services.Users
{
    public interface IUsersService
    {
        Task<User> RegisterUser(User user);
        Task<User> AuthenticateUser(User user);
        Task<User> GetUserById(int id);
        Task<bool> IsUsernameTaken(string username);
    }
}
