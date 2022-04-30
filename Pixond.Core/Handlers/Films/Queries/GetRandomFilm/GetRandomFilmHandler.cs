using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Core.Services.Films;
using AutoMapper;
using Pixond.Model.General.Queries.Films.GetRandomFilm;
using Pixond.Model.General.Queries.Films.GetAllFilms;
using System.Linq;

namespace Pixond.Core.Handlers.Films.Queries.GetRandomFilm
{
    public class GetRandomFilmHandler : IRequestHandler<GetRandomFilmQuery, GetRandomFilmResult>
    {
        private readonly IFilmsService _filmsService;
        private readonly IMapper _mapper;

        public GetRandomFilmHandler(IFilmsService filmsService, IMapper mapper)
        { 
            _filmsService = filmsService;
            _mapper = mapper;
        }
        public async Task<GetRandomFilmResult> Handle(GetRandomFilmQuery request, CancellationToken cancellationToken)
        {
            var randomFilmResult = new GetRandomFilmResult();
            var film = await _filmsService.GetRandomFilm(cancellationToken);
            randomFilmResult.Film = _mapper.Map<FilmModel>(await _filmsService.GetRandomFilm(cancellationToken));
            var f = _mapper.Map<FilmModel>(film);
            f.Genre = film.Genres.Select(g => g.Name).ToList();
            randomFilmResult.Film = f;
            return randomFilmResult;
        }
    }
}
