using AutoMapper;
using Pixond.Core.Services.Films;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Model.Entities;
using Pixond.Model.General.Queries.Films;
using Pixond.Model.General.Queries.Films.GetAllFilms;

namespace Pixond.Core.Handlers.Films.Queries.GetAllFilms
{
    public class GetAllFilmsHandler : IRequestHandler<GetAllFilmsQuery, GetAllFilmsResult>
    {
        private readonly IFilmsService _filmsService;
        private readonly IMapper _mapper;

        public GetAllFilmsHandler(IFilmsService service, IMapper mapper) 
        {
            _filmsService = service;
            _mapper = mapper;
        }

        public async Task<GetAllFilmsResult> Handle(GetAllFilmsQuery request, CancellationToken cancellationToken)
        {
            GetAllFilmsResult result = new GetAllFilmsResult();
            var films = await _filmsService.GetAllFilms(cancellationToken);
            foreach (Film film in films) 
            {
                var f = _mapper.Map<FilmModel>(film);
                f.Genre = film.Genres.Select(g => g.Name).ToList();
                result.AllFilms.Add(f);
            }
            return result;
        }
    }
}
