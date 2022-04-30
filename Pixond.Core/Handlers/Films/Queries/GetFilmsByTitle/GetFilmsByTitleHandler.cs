using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Model.General.Queries.Films;
using Pixond.Core.Services.Films;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pixond.Model.Entities;
using System.Linq;
using Pixond.Model.General.Queries.Films.GetFilmsByTitle;
using Pixond.Model.General.Queries.Films.GetAllFilms;

namespace Pixond.Core.Handlers.Films.Queries.GetFilmsByTitle
{
    public class GetFilmsByTitleHandler : IRequestHandler<GetFilmsByTitleQuery, GetFilmsByTitleResult>
    {
        private readonly IFilmsService _filmsService;
        private readonly IMapper _mapper;

        public GetFilmsByTitleHandler(IFilmsService service, IMapper mapper)
        {
            _filmsService = service;
            _mapper = mapper;
        }
        public async Task<GetFilmsByTitleResult> Handle(GetFilmsByTitleQuery request, CancellationToken cancellationToken)
        {
            var filmsResult = new GetFilmsByTitleResult();
            var films = await _filmsService.GetFilmsByTitle(request.Title, cancellationToken);
            foreach (Film film in films)
            {
                var f = _mapper.Map<FilmModel>(film);
                f.Genre = film.Genres.Select(g => g.Name).ToList();
                filmsResult.Films.Add(f);
            }
            return filmsResult;
        }
    }
}
