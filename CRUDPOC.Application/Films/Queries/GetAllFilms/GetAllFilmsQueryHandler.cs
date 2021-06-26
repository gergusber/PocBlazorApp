using AutoMapper;
using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Shared.Dto;
using CRUDPOC.Shared.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDPOC.Application.Films.Queries.GetAllFilms
{
    public class GetAllFilmsQueryHandler : IRequestQueryHandlerWrapper<GetAllFilmsQuery, IEnumerable<FilmDto>>
    {
        private readonly IFilmsApi _filmsApi;
        private readonly IMapper _mapper;

        public GetAllFilmsQueryHandler(IFilmsApi filmsApi, IMapper mapper)
        {
            _filmsApi = filmsApi;
            _mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<FilmDto>>> Handle(GetAllFilmsQuery request, CancellationToken cancellationToken)
        {
            var listOfFilms = await _filmsApi.GetAll();

            return listOfFilms.Any() ? ServiceResult.Success(_mapper.Map<IEnumerable<FilmDto>>(listOfFilms)) : ServiceResult.Failed<IEnumerable<FilmDto>>(ServiceError.NotFound);
        }
    }
}