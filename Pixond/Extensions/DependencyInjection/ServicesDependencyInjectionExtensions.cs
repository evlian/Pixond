using Pixond.Core.Abstraction.Services.Genres;
using Pixond.Core.Abstraction.Services.Users;
using Pixond.Core.Services.Films;
using Pixond.Core.Services.Genres;
using Pixond.Core.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Pixond.App.Extensions.DependencyInjection
{
    public static class ServicesDependencyInjectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFilmsService, FilmsService>();
            services.AddScoped<IGenresService, GenresService>();
            services.AddScoped<IUsersService, UsersService>();
        }
    }
}
