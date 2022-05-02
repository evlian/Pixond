using Pixond.Model.General.Commands.Users.User;

namespace Pixond.Model.General.Commands.Users.AuthenticateUser
{
    public class AuthenticateUserResponse
    {
        public PublicUser User { get; set; }
        public string Token { get; set; }
    }
}
