using MediatR;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pixond.Model.General.Commands.Films.AddFilm
{
    public class AddFilmCommand : IRequest<AddFilmResponse>
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public int CreatedBy { get; set; }
        public int Length { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<string> FilmGenres { get; set; }
    }
}
