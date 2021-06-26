using AutoMapper;
using CRUDPOC.Application.Common.Exceptions;
using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Domain.models;
using CRUDPOC.Shared.Dto;
using CRUDPOC.Shared.Helper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDPOC.Application.Developers.Commands.CreateDeveloperCommand
{
    public class DeleteDeveloperCommand : ICommandWrapper<DeveloperDto>
    {
        public int Id { get; set; }

        public class DeleteDeveloperCommandHandler : IRequestCommandHandlerWrapper<DeleteDeveloperCommand, DeveloperDto>
        {
            private readonly IDevelopersApi _developerApi;
            private readonly IMapper _mapper;

            public DeleteDeveloperCommandHandler(IDevelopersApi developerApi, IMapper mapper)
            {
                _developerApi = developerApi;
                _mapper = mapper;
            }

            public async Task<ServiceResult<DeveloperDto>> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
            {
                Developer devToUpdate = await _developerApi.GetById(request.Id);
                if (devToUpdate == null)
                {
                    throw new NotFoundException(nameof(DeveloperDto), request.Id);
                }
                await _developerApi.Remove(request.Id);

                return ServiceResult.Success(_mapper.Map<DeveloperDto>(devToUpdate));
            }
        }
    }
}