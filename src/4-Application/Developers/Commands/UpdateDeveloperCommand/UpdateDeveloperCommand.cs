using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Shared.Dto;

namespace CRUDPOC.Application.Developers.Commands.UpdateDeveloperCommand
{
    public class UpdateDeveloperCommand : ICommandWrapper<DeveloperDto>
    {
        public DeveloperDto developer { get; set; }
    }
}