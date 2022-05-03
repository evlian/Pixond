using MediatR;

namespace Pixond.Model.General.Commands.Films.DeleteFilm
{
    public class DeleteFilmCommand : IRequest<DeleteFilmResponse>
    {
        public int FilmId { get; set; }
    }
}
