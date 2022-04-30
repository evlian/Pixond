using AutoMapper;
using Pixond.Model.Entities;
using Pixond.Model.General.Queries;
using Pixond.Model.General.Queries.Films;
using Pixond.Model.General.Queries.Films.GetAllFilms;

namespace Pixond.Core.Framework.Mapping.Films.Queries.GetAllFilms
{
    public class GetAllFilmsMappings : Profile
    {
        public GetAllFilmsMappings()
        {
            CreateMap<Film, FilmModel>();
        }
    }
}
