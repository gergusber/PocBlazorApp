using CRUDPOC.Shared.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDPOC.Client.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<FilmDto>> GetAllFilms();

        Task<FilmDto> GetFilmsDetails(string id);

        Task SaveFilm(FilmDto film);

        Task<bool> DeleteFilm(string id);
    }
}