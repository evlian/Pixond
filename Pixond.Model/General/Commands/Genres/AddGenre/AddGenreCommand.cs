using MediatR;
using System.Text.Json.Serialization;

namespace Pixond.Model.General.Commands.Genres.AddGenre
{
    public class AddGenreCommand : IRequest<AddGenreResponse>
    {
        public string Name { get; set; }
        [JsonIgnore]
        public int CreatedBy { get; set; }
    }
}
