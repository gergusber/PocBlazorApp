using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Shared.Dto;
using System.Collections.Generic;

namespace CRUDPOC.Application.Films.Queries.GetAllFilms
{
    public partial class GetAllFilmsQuery : IQueryWrapper<IEnumerable<FilmDto>>
    {
    }
}