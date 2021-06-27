using AutoMapper;
using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Shared.Dto;
using CRUDPOC.Shared.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDPOC.Application.Developers.Queries.GetAllDevelopers
{
    public class GetAllDevelopersQuery : IQueryWrapper<IEnumerable<DeveloperDto>>
    {
        public class GetAllDevelopersQueryHandler : IRequestQueryHandlerWrapper<GetAllDevelopersQuery, IEnumerable<DeveloperDto>>
        {
            private readonly IDevelopersApi _developersApi;
            private readonly IMapper _mapper;

            public GetAllDevelopersQueryHandler(IDevelopersApi developerApi, IMapper mapper)
            {
                _developersApi = developerApi;
                _mapper = mapper;
            }

            public async Task<ServiceResult<IEnumerable<DeveloperDto>>> Handle(GetAllDevelopersQuery request, CancellationToken cancellationToken)
            {
                var listOfDevs = await _developersApi.GetAll();

                return listOfDevs.Any() ? ServiceResult.Success(_mapper.Map<IEnumerable<DeveloperDto>>(listOfDevs)) : ServiceResult.Failed<IEnumerable<DeveloperDto>>(ServiceError.NotFound);
            }
        }
    }
}