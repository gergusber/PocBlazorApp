using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDPOC.Domain.Services
{
    public interface IServiceMongo<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);

        Task<TEntity> GetById(string id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Update(TEntity obj);

        Task Remove(string id);
    }
}