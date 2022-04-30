using Pixond.Model.General.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Pixond.App.Extensions.DependencyInjection;
using Pixond.Model.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Pixond.Core.Abstraction.Services.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Pixond.Core.Services.Users;
using System.Linq;
using Pixond.Model.Response;
using Pixond.Model.General.Commands.Users.RegisterUser;
using Pixond.Model.General.Commands.Users.AuthenticateUser;

namespace Pixond.App.Controllers.v1
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseModel<RegisterUserResponse>>> RegisterUser([FromBody]RegisterUserCommand command)
        {
            var response = new ResponseModel<RegisterUserResponse>();
            var registerUserResponse = await Mediator.Send(command);
            if (registerUserResponse.Errors.Count > 0) 
            {
                response.AddErrors(registerUserResponse.Errors);
                return BadRequest(response.BadRequest());
            }
            return Ok(response.Ok(registerUserResponse));
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseModel<AuthenticateUserResponse>>> AuthenticateUser([FromBody]AuthenticateUserCommand command) 
        {
            var response = new ResponseModel<AuthenticateUserResponse>();
            var authUserResponse = await Mediator.Send(command);
            if (authUserResponse.User == null) 
            { 
                return Unauthorized(response.Unauthorized().AddMessage("Username or password is incorrect!"));
            }
            return Ok(response.Ok(authUserResponse));
        }
    }
}
