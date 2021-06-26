using CRUDPOC.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDPOC.Data.Dapper.Repositories
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetAllFilms();

        Task<Film> GetFilmsDetails(int id);

        Task<bool> InsertFilm(Film film);

        Task<bool> UpdateFilm(Film film);

        Task<bool> DeleteFilm(int id);
    }
}