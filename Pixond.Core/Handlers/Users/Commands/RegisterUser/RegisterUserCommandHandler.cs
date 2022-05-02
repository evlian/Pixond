using Pixond.Core.Abstraction.Services.Users;
using Pixond.Model.Entitites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Core.Tools;
using Pixond.Core.Utilities;
using Pixond.Model.General.Commands.Users.RegisterUser;
using System;
using AutoMapper;
using Pixond.Model.General.Commands.Users.User;
using Pixond.Core.Configurations;
using Pixond.Core.Abstraction.Services.Mail;

namespace Pixond.Core.Handlers.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        private readonly EncryptionConfiguration _encryptionConfiguration;
        private readonly IMailService _mailService;

        public RegisterUserCommandHandler(IUsersService service, IMapper mapper, EncryptionConfiguration encryptionConfiguration, IMailService mailService) 
        { 
            _usersService = service;
            _mapper = mapper;
            _encryptionConfiguration = encryptionConfiguration;
            _mailService = mailService;
        }
        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            user.UserId = Guid.NewGuid();
            user.Username = request.Username;
            user.Password = PasswordUtilities.EncryptPassword(request.Password, _encryptionConfiguration.SecretString);
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.CreatedBy = "system";
            user.CreatedAt = DateTime.Now;
            user.ModifiedAt = DateTime.Now;
            var response = new RegisterUserResponse();
            if (await _usersService.IsUsernameTaken(user.Username))
            {
                return null;
            }
            var registeredUser = await _usersService.RegisterUser(user);
            response.User = _mapper.Map<PublicUser>(registeredUser);
            response.Token = TokenUtilities.GenerateToken(registeredUser);
            _mailService.SendMail("Pixond", response.User.Email, "Confirm your email address", "Welcome to Pixond!");
            return response;
        }

        
    }
}
