using Pixond.Core.Abstraction.Services.Users;
using Pixond.Model.Entitites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Core.Tools;
using Pixond.Core.Utilities;
using Pixond.Model.General.Commands.Users.AuthenticateUser;
using AutoMapper;
using Pixond.Model.General.Commands.Users.User;
using Pixond.Core.Configurations;

namespace Pixond.Core.Handlers.Users.Commands.AuthenticateUser
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResponse>
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        private readonly EncryptionConfiguration _encryptionConfiguration;

        public AuthenticateUserCommandHandler(IUsersService service, IMapper mapper, EncryptionConfiguration encryptionConfiguration)
        {
            _usersService = service;
            _mapper = mapper;
            _encryptionConfiguration = encryptionConfiguration;
        }
        public async Task<AuthenticateUserResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            AuthenticateUserResponse response = new AuthenticateUserResponse();
            request.Password = PasswordUtilities.EncryptPassword(request.Password, _encryptionConfiguration.SecretString);
            User user = new User() { Username = request.Username, Password = request.Password};
            var authenticatedUser = await _usersService.AuthenticateUser(user);
            if (authenticatedUser == null)
                return response;
            response.User = _mapper.Map<PublicUser>(authenticatedUser);
            response.Token = (TokenUtilities.GenerateToken(authenticatedUser));
            return response;
        }
    }
}
