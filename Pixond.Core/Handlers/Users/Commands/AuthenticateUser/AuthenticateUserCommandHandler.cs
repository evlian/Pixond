using Pixond.Core.Abstraction.Services.Users;
using Pixond.Model.Entitites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Core.Tools;
using Pixond.Core.Utilities;
using Pixond.Model.General.Commands.Users.AuthenticateUser;

namespace Pixond.Core.Handlers.Users.Commands.AuthenticateUser
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResponse>
    {
        private readonly IUsersService _usersService;
        public AuthenticateUserCommandHandler(IUsersService service)
        {
            _usersService = service;
        }
        public async Task<AuthenticateUserResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            AuthenticateUserResponse response = new AuthenticateUserResponse();
            request.Password = PasswordUtilities.EncryptPassword(request.Password);
            User user = new User() { Username = request.Username, Password = request.Password};
            var s = await _usersService.AuthenticateUser(user);
            response.User = s;
            if (response.User == null)
                return response;
            response.Token = (TokenUtilities.GenerateToken(response.User));
            return response;
        }
    }
}
