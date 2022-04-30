using AutoMapper;
using Pixond.Model;
using Pixond.Model.General.Commands.Genres.AddGenre;

namespace Pixond.Core.Framework.Mapping.Genres.Commands.AddGenre
{
    public class AddGenreMappings : Profile
    {
        public AddGenreMappings()
        {
            CreateMap<AddGenreCommand, Genre>();
        }
    }
}
