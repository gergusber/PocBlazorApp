using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Shared.Dto;

namespace CRUDPOC.Application.Films.Commands.DeleteFilmCommand
{
    public class DeleteFilmCommand : ICommandWrapper<FilmDto>
    {
        public string Id { get; set; }
    }
}