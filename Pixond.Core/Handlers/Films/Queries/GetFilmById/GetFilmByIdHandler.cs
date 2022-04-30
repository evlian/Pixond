using AutoMapper;
using Pixond.Core.Services.Films;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Model.General.Queries.Films;
using Pixond.Model.General.Queries.Films.GetFilmById;
using Pixond.Model.General.Queries.Films.GetAllFilms;

namespace Pixond.Core.Handlers.Films.Queries.GetAllFilms
{
    public class GetFilmByIdHandler : IRequestHandler<GetFilmByIdQuery, GetFilmByIdResult>
    {
        private readonly IFilmsService _filmsService;
        private readonly IMapper _mapper;

        public GetFilmByIdHandler(IFilmsService service, IMapper mapper)
        {
            _filmsService = service;
            _mapper = mapper;
        }

        public async Task<GetFilmByIdResult> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
        {
            var film = await _filmsService.GetFilmById(request.Id, cancellationToken);
            var filmModel = _mapper.Map<FilmModel>(film);
            return new GetFilmByIdResult
            {
                Film = filmModel,
            };
        }
    }
}
