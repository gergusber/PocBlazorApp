using AutoMapper;
using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Domain.models;
using CRUDPOC.Shared.Dto;
using CRUDPOC.Shared.Helper;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDPOC.Application.Films.Commands.CreateFilmCommand
{
    public class CreateFilmCommandHandler : IRequestCommandHandlerWrapper<CreateFilmCommand, FilmDto>
    {
        private readonly IFilmsApi _filmApi;
        private readonly IMapper _mapper;

        public CreateFilmCommandHandler(IFilmsApi filmApi, IMapper mapper)
        {
            _filmApi = filmApi;
            _mapper = mapper;
        }

        public async Task<ServiceResult<FilmDto>> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            var retur = await _filmApi.Add(_mapper.Map<Film>(request.film));
            return ServiceResult.Success(_mapper.Map<FilmDto>(retur));
        }
    }
}