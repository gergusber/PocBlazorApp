using AutoMapper;
using CRUDPOC.Application.Common.Exceptions;
using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Domain.models;
using CRUDPOC.Shared.Dto;
using CRUDPOC.Shared.Helper;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDPOC.Application.Developers.Commands.CreateDeveloperCommand
{
    public class UpdateDeveloperCommandHandler : IRequestCommandHandlerWrapper<UpdateDeveloperCommand, DeveloperDto>
    {
        private readonly IDevelopersApi _developerApi;
        private readonly IMapper _mapper;

        public UpdateDeveloperCommandHandler(IDevelopersApi developerApi, IMapper mapper)
        {
            _developerApi = developerApi;
            _mapper = mapper;
        }

        public async Task<ServiceResult<DeveloperDto>> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {
            Developer devToUpdate = await _developerApi.GetById(request.developer.Id);
            if (devToUpdate == null)
            {
                throw new NotFoundException(nameof(Developer), request.developer.Id);
            }
            devToUpdate.FirstName = request.developer.FirstName;
            devToUpdate.LastName = request.developer.LastName;
            devToUpdate.Email = request.developer.Email;
            devToUpdate.Experience = request.developer.Experience;

            var updatedDeveloper = await _developerApi.Update(devToUpdate);

            return updatedDeveloper != null ? ServiceResult.Success(_mapper.Map<DeveloperDto>(updatedDeveloper)) : ServiceResult.Failed<DeveloperDto>(ServiceError.NotFound);
        }
    }
}