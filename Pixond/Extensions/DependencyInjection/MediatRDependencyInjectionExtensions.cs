using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pixond.Core.Handlers.Films.Commands.AddFilm;
using Pixond.Core.Handlers.Films.Commands.EditFilm;
using Pixond.Core.Handlers.Films.Queries.GetAllFilms;
using Pixond.Core.Handlers.Films.Queries.GetFilmsByTitle;
using Pixond.Core.Handlers.Films.Queries.GetRandomFilm;
using Pixond.Core.Handlers.Genres.Commands.AddGenre;
using Pixond.Core.Handlers.Genres.Queries.GetAllGenres;
using Pixond.Core.Handlers.Users.Commands.AuthenticateUser;
using Pixond.Core.Handlers.Users.Commands.RegisterUser;
using Pixond.Model.General.Commands.Films.AddFilm;
using Pixond.Model.General.Commands.Films.EditFilm;
using Pixond.Model.General.Commands.Genres.AddGenre;
using Pixond.Model.General.Commands.Users.AuthenticateUser;
using Pixond.Model.General.Commands.Users.RegisterUser;
using Pixond.Model.General.Queries.Films.GetAllFilms;
using Pixond.Model.General.Queries.Films.GetFilmById;
using Pixond.Model.General.Queries.Films.GetFilmsByTitle;
using Pixond.Model.General.Queries.Films.GetRandomFilm;
using Pixond.Model.General.Queries.Genres.GetAllGenres;

namespace Pixond.App.Extensions.DependencyInjection
{
    public static class MediatRDependencyInjectionExtensions
    {
        public static void AddMediatRExtension(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
        }

        public static void AddCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<AddFilmCommand, AddFilmResponse>, AddFilmCommandHandler>();
            services.AddTransient<IRequestHandler<AddGenreCommand, AddGenreResponse>, AddGenreCommandHandler>();
            services.AddTransient<IRequestHandler<EditFilmCommand, EditFilmResponse>, EditFilmCommandHandler>();
            services.AddTransient<IRequestHandler<RegisterUserCommand, RegisterUserResponse>, RegisterUserCommandHandler>();
            services.AddTransient<IRequestHandler<AuthenticateUserCommand, AuthenticateUserResponse>, AuthenticateUserCommandHandler>();
        }

        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetAllFilmsQuery, GetAllFilmsResult>, GetAllFilmsHandler>();
            services.AddTransient<IRequestHandler<GetFilmByIdQuery, GetFilmByIdResult>, GetFilmByIdHandler>();
            services.AddTransient<IRequestHandler<GetRandomFilmQuery, GetRandomFilmResult>, GetRandomFilmHandler>();
            services.AddTransient<IRequestHandler<GetFilmsByTitleQuery, GetFilmsByTitleResult>, GetFilmsByTitleHandler>();
            services.AddTransient<IRequestHandler<GetAllGenresQuery, GetAllGenresResult>, GetAllGenresHandler>();
        }
    }
}
