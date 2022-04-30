using Pixond.Model.General.Queries.Genres;
using Pixond.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Model.General.Commands.Genres;
using Pixond.Model.General.Queries.Genres.GetAllGenres;

namespace Pixond.Core.Abstraction.Services.Genres
{
    public interface IGenresService
    {
        Task<List<Genre>> GetAllGenres(GetAllGenresQuery query, CancellationToken cancellationToken);
        Task<Genre> AddGenre(Genre genre, CancellationToken cancellationToken);
    }
}
