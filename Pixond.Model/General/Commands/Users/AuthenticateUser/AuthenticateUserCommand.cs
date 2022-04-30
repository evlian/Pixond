using MediatR;

namespace Pixond.Model.General.Commands.Users.AuthenticateUser
{
    public class AuthenticateUserCommand : IRequest<AuthenticateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
