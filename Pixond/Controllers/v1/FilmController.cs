
using Pixond.App.Controllers;
using Pixond.Core.Extensions.Validation;
using Pixond.Core.Framework.Validation.Films.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Pixond.Model.Response;
using Pixond.Model.General.Queries.Films.GetAllFilms;
using Pixond.Model.General.Queries.Films.GetFilmById;
using Pixond.Model.General.Commands.Films.AddFilm;
using Pixond.Model.General.Queries.Films.GetRandomFilm;
using Pixond.Model.General.Queries.Films.GetFilmsByTitle;
using Pixond.Model.General.Commands.Films.EditFilm;

namespace Pixond.Controllers
{
    [Route("api/v1/films")]
    [ApiController]
    public class FilmController : BaseController
    {
        private readonly ILogger<FilmController> _logger;

        public FilmController(ILogger<FilmController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ResponseModel<GetAllFilmsResult>>> GetAllFilms()
        {
            var response = new ResponseModel<GetAllFilmsResult>();

            var filmsResult = await Mediator.Send(new GetAllFilmsQuery());
            if (filmsResult.AllFilms == null)
                return NotFound(response.AddMessage("No data was found!").NotFound());
            return Ok(response.Ok(filmsResult));
        }

        [HttpGet("id/{id:int}")]
        public async Task<ActionResult<ResponseModel<GetFilmByIdResult>>> GetFilmById([FromRoute]int id) 
        {
            var response = new ResponseModel<GetFilmByIdResult>();
            var query = new GetFilmByIdQuery() { Id = id };
            var validator = new GetFilmByIdValidation().Validate(query);
            if (!validator.IsValid)
            {
                response.AddError("Invalid ID", "ID must not be 0 or less than 0.");
                return BadRequest(response.BadRequest());
                
            }
            var film = await Mediator.Send(query);
            if (film.Film == null)
                return NotFound(response.AddMessage("No data was found!").NotFound());
            return Ok(response.Ok(film));
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<ResponseModel<AddFilmResponse>> >AddFilm([FromBody] AddFilmCommand command)
        {
            var response = new ResponseModel<AddFilmResponse>();
            int id = -1;
            int.TryParse(HttpContext.User.Claims.FirstOrDefault().Value, out id);
            if (id == -1) 
            {
                return Unauthorized(response.Unauthorized().AddMessage("User is not authorized!"));
            }
            command.CreatedBy = id;
            if (!ModelState.IsValid) 
            {
                response.AddErrors(ModelState.GetErrorMessages());
                BadRequest(response.BadRequest());
            }
            var addFilmResponse = await Mediator.Send(command);
            return Ok(response.Ok(addFilmResponse));
        }

        [HttpGet("random")]
        public async Task<GetRandomFilmResult> GetRandom()
        {
            return await Mediator.Send(new GetRandomFilmQuery());
        }

        [HttpGet("title/{title}")]
        public async Task<ActionResult<ResponseModel<GetFilmsByTitleResult>>> GetFilmByTitle([FromRoute]string title)
        {
            var query = new GetFilmsByTitleQuery();
            query.Title = title;
            var response = new ResponseModel<GetFilmsByTitleResult>();
            var result = await Mediator.Send(query);
            if (result.Films == null)
                return NotFound(response.AddMessage("No data was found!").NotFound());
            return Ok(response.Ok(result));
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ResponseModel<EditFilmResponse>>> EditFilm([FromBody]EditFilmCommand command)
        {
            var response = new ResponseModel<EditFilmResponse>();
            var editFilmResponse = await Mediator.Send(command);
            return Ok(response.Ok(editFilmResponse));
        }
    }
}
