using AutoMapper;
using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Domain.models;
using CRUDPOC.Shared.Dto;
using CRUDPOC.Shared.Helper;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDPOC.Application.Developers.Commands.CreateDeveloperCommand
{
    public class CreateDeveloperCommand : ICommandWrapper<DeveloperDto>
    {
        public DeveloperDto developer { get; set; }

        public class CreateDeveloperCommandHandler : IRequestCommandHandlerWrapper<CreateDeveloperCommand, DeveloperDto>
        {
            private readonly IDevelopersApi _developerApi;
            private readonly IMapper _mapper;

            public CreateDeveloperCommandHandler(IDevelopersApi developerApi, IMapper mapper)
            {
                _developerApi = developerApi;
                _mapper = mapper;
            }

            public async Task<ServiceResult<DeveloperDto>> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
            {
                var retur = await _developerApi.Add(_mapper.Map<Developer>(request.developer));
                return ServiceResult.Success(_mapper.Map<DeveloperDto>(retur));
            }
        }
    }
}