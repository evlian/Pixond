using FluentValidation;
using Pixond.Model.General.Queries.Films.GetFilmsByTitle;

namespace Pixond.Core.Framework.Validation.Films.Queries.GetAllFilms
{
    public class GetAllFilmsValidation : AbstractValidator<GetFilmsByTitleQuery>
    {
        public GetAllFilmsValidation() 
        { 
            
        }
    }
}
