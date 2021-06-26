using CRUDPOC.Data.EfCore.Configure;
using CRUDPOC.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDPOC.Data.EfCore
{
    public abstract class BaseRepositoryEf<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDBContext _context;

        public BaseRepositoryEf(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<TEntity> Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return (IEnumerable<TEntity>)await _context.Developers.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(string id)
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

        //private Task<TEntity> Add(TEntity obj)
        //{
        //    throw new NotImplementedException();
        //}

        //private Task<TEntity> Update(TEntity obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}