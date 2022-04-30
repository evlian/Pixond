using MediatR;

namespace Pixond.Model.General.Queries.Films.GetFilmsByTitle
{
    public class GetFilmsByTitleQuery : IRequest<GetFilmsByTitleResult>
    {
        public string Title { get; set; }
    }
}
