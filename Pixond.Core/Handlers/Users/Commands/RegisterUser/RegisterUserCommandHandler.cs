using Pixond.Core.Abstraction.Services.Users;
using Pixond.Model.Entitites;
using Pixond.Model.General.Commands.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Core.Tools;
using System.Collections.Generic;
using Pixond.Core.Utilities;
using Pixond.Model.General.Commands.Users.RegisterUser;

namespace Pixond.Core.Handlers.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IUsersService _service;

        public RegisterUserCommandHandler(IUsersService service) 
        { 
            _service = service;
        }
        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            user.Username = request.Username;
            user.Password = PasswordUtilities.EncryptPassword(request.Password);
            user.Name = request.Name;
            var response = new RegisterUserResponse();
            if (await _service.IsUsernameTaken(user.Username))
            {
                response.Errors.TryAdd("username", new List<string>() { "Username is taken!" });
                return response;
            }
            response.User = await _service.RegisterUser(user);
            response.Token = TokenUtilities.GenerateToken(response.User);
            return response;
        }

        
    }
}
