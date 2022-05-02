using Pixond.Model.General.Commands.Users.User;

namespace Pixond.Model.General.Commands.Users.RegisterUser
{
    public class RegisterUserResponse
    {
        public PublicUser User { get; set; }
        public string Token { get; set; }
    }
}
