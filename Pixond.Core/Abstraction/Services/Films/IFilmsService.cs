using Pixond.Model.Entities;
using Pixond.Model.General.Commands.Films;
using Pixond.Model.General.Commands.Films.AddFilm;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pixond.Core.Services.Films
{
    public interface IFilmsService
    {
        public Task<List<Film>> GetAllFilms(CancellationToken cancellationToken);
        public Task<Film> GetFilmById(int id, CancellationToken cancellationToken);
        public Task<List<Film>> GetFilmsByTitle(string title, CancellationToken cancellationToken);
        public Task<Film> GetRandomFilm(CancellationToken cancellationToken);
        public Task<Film> AddFilm(AddFilmCommand film, CancellationToken cancellation);
        public Task<Film> EditFilm(Film film, int id, CancellationToken cancellationToken);
        
    }
}
