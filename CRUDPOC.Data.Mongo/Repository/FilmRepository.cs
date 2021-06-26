using CRUDPOC.Domain.Config;
using CRUDPOC.Domain.Interfaces;
using CRUDPOC.Domain.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDPOC.Data.Mongo.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly IMongoCollection<Film> _films;

        public FilmRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _films = database.GetCollection<Film>(settings.FilmsCollectionName);
        }

        public async Task<Film> Add(Film obj)
        {
            try
            {
                _films.InsertOne(obj);
                return await _films.Find(film => film.Id == obj.Id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
        }

        public async Task<IEnumerable<Film>> GetAll()
        {
            return await _films.Find(film => true).ToListAsync();
        }

        public async Task<Film> GetById(string id)
        {
            var resp = await _films.Find(book => book.Id == id).FirstOrDefaultAsync();
            return resp;
        }

        public async Task Remove(string id)
        {
            try
            {
                await _films.DeleteOneAsync(book => book.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Film> Update(Film obj)
        {
            try
            {
                _films.ReplaceOne(film => film.Id == obj.Id, obj);
                return await _films.Find(film => film.Id == obj.Id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}