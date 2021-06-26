using CRUDPOC.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDPOC.Infraestructure.Services
{
    public class ServiceBase<TEntity> : IService<TEntity> where TEntity : class
    {
        public Task<TEntity> Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}