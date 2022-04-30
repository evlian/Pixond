using MediatR;

namespace Pixond.Model.General.Queries.Films.GetAllFilms
{
    public class GetAllFilmsQuery : IRequest<GetAllFilmsResult>
    {
        public string Title { get; set; }
    }
}
