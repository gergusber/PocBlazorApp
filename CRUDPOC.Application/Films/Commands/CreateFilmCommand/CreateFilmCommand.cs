using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Shared.Dto;

namespace CRUDPOC.Application.Films.Commands.CreateFilmCommand
{
    public class CreateFilmCommand : ICommandWrapper<FilmDto>
    {
        public FilmDto film { get; set; }
    }
}