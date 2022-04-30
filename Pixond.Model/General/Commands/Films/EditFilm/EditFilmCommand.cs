using MediatR;
using Pixond.Model.General.Queries.Films.GetAllFilms;

namespace Pixond.Model.General.Commands.Films.EditFilm
{
    public class EditFilmCommand : IRequest<EditFilmResponse>
    {
        public int Id { get; set; }
        public FilmModel Film { get; set; }
    }
}
