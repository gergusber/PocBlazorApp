using CRUDPOC.Application.Films;
using CRUDPOC.Domain.Interfaces;
using CRUDPOC.Domain.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDPOC.Infraestructure.Services
{
    public class FilmService : IFilmsApi//IFilmService
    {
        private readonly IFilmRepository _filmRepo;

        public FilmService(IFilmRepository filmRepo)
        {
            _filmRepo = filmRepo;
        }

        /// <summary>
        /// Specific method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<Film> AddFunction(Film obj)
        {
            await _filmRepo.Add(obj);
            return obj;
        }

        public async Task<Film> Add(Film obj) => await _filmRepo.Add(obj);

        public async Task<IEnumerable<Film>> GetAll() => await _filmRepo.GetAll();

        public async Task<Film> GetById(string id) => await _filmRepo.GetById(id);

        public async Task<Film> Update(Film obj) => await _filmRepo.Update(obj);

        public async Task Remove(string id) => await _filmRepo.Remove(id);
    }
}