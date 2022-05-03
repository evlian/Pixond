using MediatR;
using Pixond.Core.Services.Films;
using Pixond.Model.General.Commands.Films.DeleteFilm;
using System.Threading;
using System.Threading.Tasks;

namespace Pixond.Core.Handlers.Films.Commands.DeleteFilm
{
    public class DeleteFilmHandler : IRequestHandler<DeleteFilmCommand, DeleteFilmResponse>
    {
        private readonly IFilmsService _filmsService;

        public DeleteFilmHandler(IFilmsService filmsService)
        { 
            _filmsService = filmsService;
        }


        public async Task<DeleteFilmResponse> Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteFilmResponse();

            if (await _filmsService.DeleteFilmAsync(request.FilmId, cancellationToken))
            {
                response.IsDeleted = true;
            }
            return response;
        }
    }
}
