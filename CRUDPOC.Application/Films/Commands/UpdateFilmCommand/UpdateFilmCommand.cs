using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Shared.Dto;

namespace CRUDPOC.Application.Films.Commands.UpdateFilmCommand
{
    public class UpdateFilmCommand : ICommandWrapper<FilmDto>
    {
        public FilmDto filmToUpdate { get; set; }
    }
}