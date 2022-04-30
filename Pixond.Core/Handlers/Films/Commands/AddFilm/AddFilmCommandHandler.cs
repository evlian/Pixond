using Pixond.Core.Services.Films;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Model.General.Commands.Films.AddFilm;

namespace Pixond.Core.Handlers.Films.Commands.AddFilm
{
    public class AddFilmCommandHandler : IRequestHandler<AddFilmCommand, AddFilmResponse>
    {
        private readonly IFilmsService _filmsService;

        public AddFilmCommandHandler(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }
        public async Task<AddFilmResponse> Handle(AddFilmCommand request, CancellationToken cancellationToken)
        {
            return new AddFilmResponse() { Film = await _filmsService.AddFilm(request, cancellationToken) };
        }
    }
}
