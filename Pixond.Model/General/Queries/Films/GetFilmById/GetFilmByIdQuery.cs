using MediatR;
using System.Text.Json.Serialization;

namespace Pixond.Model.General.Queries.Films.GetFilmById
{
    public class GetFilmByIdQuery : IRequest<GetFilmByIdResult>
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
