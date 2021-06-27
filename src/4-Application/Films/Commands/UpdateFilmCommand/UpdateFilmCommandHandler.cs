using AutoMapper;
using CRUDPOC.Application.Common.Exceptions;
using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Domain.models;
using CRUDPOC.Shared.Dto;
using CRUDPOC.Shared.Helper;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDPOC.Application.Films.Commands.UpdateFilmCommand
{
    public class UpdateFilmCommandHandler : IRequestCommandHandlerWrapper<UpdateFilmCommand, FilmDto>
    {
        private readonly IFilmsApi _filmApi;
        private readonly IMapper _mapper;

        public UpdateFilmCommandHandler(IFilmsApi filmApi, IMapper mapper)
        {
            _filmApi = filmApi;
            _mapper = mapper;
        }

        public async Task<ServiceResult<FilmDto>> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            Film filmToUpdate = await _filmApi.GetById(request.filmToUpdate.Id);
            if (filmToUpdate == null)
            {
                throw new NotFoundException(nameof(Film), request.filmToUpdate.Id);
            }

            filmToUpdate.Title = request.filmToUpdate.Title;
            filmToUpdate.ReleaseDate = request.filmToUpdate.ReleaseDate;
            filmToUpdate.Director = request.filmToUpdate.Director;

            var updatedFilm = await _filmApi.Update(filmToUpdate);

            return updatedFilm != null ? ServiceResult.Success(_mapper.Map<FilmDto>(updatedFilm)) :
                ServiceResult.Failed<FilmDto>(ServiceError.NotFound);
        }
    }
}