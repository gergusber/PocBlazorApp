using CRUDPOC.Domain.models;
using System.Threading.Tasks;

namespace CRUDPOC.Domain.Services
{
    public interface IFilmService : IServiceMongo<Film>
    {
        Task<Film> AddFunction(Film obj);
    }
}