using AutoMapper;
using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Shared.Dto;
using CRUDPOC.Shared.Helper;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDPOC.Application.Films.Queries.GetFilmById
{
    public class GetFilmByIdHandler : IRequestQueryHandlerWrapper<GetFilmByIdQuery, FilmDto>
    {
        private readonly IFilmsApi _filmsApi;
        private readonly IMapper _mapper;

        public GetFilmByIdHandler(IFilmsApi filmsApi, IMapper mapper)
        {
            _filmsApi = filmsApi;
            _mapper = mapper;
        }

        public async Task<ServiceResult<FilmDto>> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
        {
            var film = await _filmsApi.GetById(request.Id);

            return film != null ? ServiceResult.Success(_mapper.Map<FilmDto>(film)) : ServiceResult.Failed<FilmDto>(ServiceError.NotFound);
        }
    }
}