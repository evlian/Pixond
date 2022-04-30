using Pixond.Model.Entitites;

namespace Pixond.Model.General.Commands.Users.AuthenticateUser
{
    public class AuthenticateUserResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
