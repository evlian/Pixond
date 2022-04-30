using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Pixond.Core.Abstraction.Services.Users;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixond.App.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //public async Task Invoke(HttpContext context, IUsersService usersService)
        //{
        //}
    }
}
