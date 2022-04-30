using AutoMapper;
using Pixond.Core.Abstraction.Services.Genres;
using Pixond.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Model.General.Commands.Genres.AddGenre;

namespace Pixond.Core.Handlers.Genres.Commands.AddGenre
{
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, AddGenreResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenresService _service; 

        public AddGenreCommandHandler(IMapper mapper, IGenresService service)
        { 
            _mapper = mapper;
            _service = service;
        }
        public async Task<AddGenreResponse> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = _mapper.Map<Genre>(request);
            await _service.AddGenre(genre, cancellationToken);
            return new AddGenreResponse(); 
        }
    }
}
