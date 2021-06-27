using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Shared.Dto;

namespace CRUDPOC.Application.Films.Queries.GetFilmById
{
    public class GetFilmByIdQuery : IQueryWrapper<FilmDto>
    {
        public string Id { get; set; }
    }
}