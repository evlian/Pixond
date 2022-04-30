using Pixond.Model.General.Queries.Films.GetAllFilms;
using System.Collections.Generic;

namespace Pixond.Model.General.Queries.Films.GetFilmsByTitle
{
    public class GetFilmsByTitleResult
    {
        public ICollection<FilmModel> Films { get; set; } = new List<FilmModel>();
    }
}
