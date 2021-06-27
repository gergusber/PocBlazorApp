using AutoMapper;
using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Shared.Dto;
using CRUDPOC.Shared.Helper;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDPOC.Application.Developers.Queries.GetDeveloperById
{
    public class GetDeveloperByIdQueryHandler : IRequestQueryHandlerWrapper<GetDeveloperByIdQuery, DeveloperDto>
    {
        private readonly IDevelopersApi _developersApi;
        private readonly IMapper _mapper;

        public GetDeveloperByIdQueryHandler(IDevelopersApi postsApi, IMapper mapper)
        {
            _developersApi = postsApi;
            _mapper = mapper;
        }

        public async Task<ServiceResult<DeveloperDto>> Handle(GetDeveloperByIdQuery request, CancellationToken cancellationToken)
        {
            var developer = await _developersApi.GetById(request.Id);

            return developer != null ? ServiceResult.Success(_mapper.Map<DeveloperDto>(developer)) : ServiceResult.Failed<DeveloperDto>(ServiceError.NotFound);
        }
    }
}