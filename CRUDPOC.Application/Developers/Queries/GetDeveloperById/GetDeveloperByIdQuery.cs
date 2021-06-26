using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Domain.models;
using CRUDPOC.Shared.Dto;

namespace CRUDPOC.Application.Developers.Queries.GetDeveloperById
{
    public class GetDeveloperByIdQuery : IQueryWrapper<DeveloperDto>
    {
        public int Id { get; set; }
    }
}