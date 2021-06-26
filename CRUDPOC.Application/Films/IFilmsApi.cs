using CRUDPOC.Domain.models;
using CRUDPOC.Domain.Services;

namespace CRUDPOC.Application.Films
{
    public interface IFilmsApi : IServiceMongo<Film>
    {
    }
}