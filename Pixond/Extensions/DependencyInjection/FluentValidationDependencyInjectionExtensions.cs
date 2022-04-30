using Pixond.Core.Framework.Validation.Films.Queries;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pixond.App.Extensions.DependencyInjection
{
    public static class FluentValidationDependencyInjectionExtensions
    {
        public static void AddFluentValidationExtension(this IMvcBuilder mvc)
        {
            mvc.AddFluentValidation(opt => {
                var assemblies = new Assembly[] {
                    typeof(GetFilmByIdValidation).Assembly,
                };
                opt.RegisterValidatorsFromAssemblies(assemblies);
                opt.ImplicitlyValidateChildProperties = true;
            });
        }
    }
}
