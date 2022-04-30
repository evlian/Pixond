using AutoMapper;
using Pixond.Core.Abstraction.Services.Genres;
using Pixond.Model.General.Queries.Genres;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Model.General.Queries.Genres.GetAllGenres;

namespace Pixond.Core.Handlers.Genres.Queries.GetAllGenres
{
    public class GetAllGenresHandler : IRequestHandler<GetAllGenresQuery, GetAllGenresResult>
    {
        private readonly IGenresService _service;
        private readonly IMapper _mapper;

        public GetAllGenresHandler(IGenresService service, IMapper mapper) 
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<GetAllGenresResult> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            return new GetAllGenresResult() { Genres = await _service.GetAllGenres(request, cancellationToken) };
        }
    }
}
