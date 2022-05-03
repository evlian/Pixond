using Pixond.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Model.Entities;
using Pixond.Model.General.Commands.Films;
using Pixond.Model.General.Commands.Films.AddFilm;

namespace Pixond.Core.Services.Films
{
    public class FilmsService : IFilmsService
    {
        private readonly ILogger<FilmsService> _logger;
        private readonly FilmLibraryContext _context;

        public FilmsService(ILogger<FilmsService> logger, FilmLibraryContext context)
        { 
            _logger = logger;
            _context = context;
        }

        public async Task<Film> AddFilm(AddFilmCommand command, CancellationToken cancellation)
        {
            Film film = new() { Description = command.Description, Director = command.Director, Title = command.Title, Length = command.Length , ReleaseDate = command.ReleaseDate};
            film.CreatedAt = DateTime.Now;
            film.CreatedBy = command.CreatedBy;
            film.ModifiedAt = DateTime.Now;
            film.ModifiedBy = command.CreatedBy;
            _context.Add(film);
            await _context.SaveChangesAsync();
            var filmContext = _context.Films
                                .Include(x => x.Genres)
                                .Include(x => x.Genres)
                                .First(x => x.Title == film.Title);
            foreach (string genre in command.FilmGenres)
            {
                var existing = await _context.Genres.FirstOrDefaultAsync(g => g.Name.Equals(genre));
                filmContext.Genres.Add(existing);
            }
            await _context.SaveChangesAsync();
            return filmContext;
        }

        public async Task<bool> DeleteFilmAsync(int id, CancellationToken cancellationToken)
        {
            var film = await _context.Films.FindAsync(id);
            _context.Films.Remove(film);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Film> EditFilm(Film film, int id, CancellationToken cancellationToken)
        {
            film.FilmId = id;
            var oldFilm = await GetFilmById(id, cancellationToken);
            if (film.Title != null)
                oldFilm.Title = film.Title;
            if (film.Description != null)
                oldFilm.Description = film.Description;
            if (film.Director != null)
                oldFilm.Director = film.Director;
            if (film.ReleaseDate != DateTime.MinValue)
                oldFilm.ReleaseDate = film.ReleaseDate;
            _context.Entry(oldFilm).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return film;
        }

        public async Task<List<Film>> GetAllFilms(CancellationToken cancellationToken)
        {
            return await _context.Films.Include(x => x.Genres).ToListAsync(cancellationToken);
        }

        public async Task<Film> GetFilmById(int id, CancellationToken cancellationToken)
{
            return await _context.Films.FindAsync(id);
        }

        public async Task<List<Film>> GetFilmsByTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.Films.Include(g => g.Genres).Where(film => film.Title == title).ToListAsync();
        }

        public async Task<Film> GetRandomFilm(CancellationToken cancellationToken)
        {
            return await _context.Films.Include(g => g.Genres).OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefaultAsync(cancellationToken);
        }

        
    }
}
