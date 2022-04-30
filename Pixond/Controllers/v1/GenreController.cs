using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Pixond.Model.Response;
using Pixond.Model.General.Queries.Genres.GetAllGenres;
using Pixond.Model.General.Commands.Genres.AddGenre;

namespace Pixond.App.Controllers
{
    [Route("api/v1/genres")]
    [ApiController]
    public class GenreController : BaseController
    {
        private readonly ILogger<GenreController> _logger;

        public GenreController(ILogger<GenreController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ResponseModel<GetAllGenresResult>>> GetAllGenres()
        {
            var response = new ResponseModel<GetAllGenresResult>();
            var result = await Mediator.Send(new GetAllGenresQuery());
            if (result.Genres.Count == 0) 
            {
                return NotFound(response.NotFound().AddMessage("No data was found!"));   
            }
            return Ok(response.Ok(result));
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<ResponseModel<AddGenreResponse>>> AddGenre([FromBody] AddGenreCommand command)
        {
            var response = new ResponseModel<AddGenreResponse>();
            int id;
            int.TryParse(HttpContext.User.Claims.FirstOrDefault().Value, out id);
            if (id == 0)
            {
                return Unauthorized(response.Unauthorized().AddMessage("Unauthorized request!"));
            }
            command.CreatedBy = id;
            var addGenreResponse = await Mediator.Send(command);
            return Ok(response.Ok(addGenreResponse));
        }
    }
}
