using CRUDPOC.Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDPOC.Data.Mongo
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class

    {
        protected readonly IMongoCollection<TEntity> DbSet;

        public Task<TEntity> Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
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
    }
}