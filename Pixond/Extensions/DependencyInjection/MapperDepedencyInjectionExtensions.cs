using AutoMapper;
using Pixond.Core.Framework.Mapping.Films.Queries.GetAllFilms;
using Pixond.Core.Framework.Mapping.Genres.Commands.AddGenre;
using Microsoft.Extensions.DependencyInjection;

namespace Pixond.App.Extensions.DependencyInjection
{
    public static class MapperDepedencyInjectionExtensions
    {

        public static void AddMappingWithProfiles(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GetAllFilmsMappings>();
                cfg.AddProfile<AddGenreMappings>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
