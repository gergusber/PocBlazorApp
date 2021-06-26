using CRUDPOC.Domain.models;
using DotNetCore.Repositories;

namespace CRUDPOC.Data.EfCore5.Repository
{
    public interface IDeveloperTestRepository : IRepository<Developer>
    {
    }
}