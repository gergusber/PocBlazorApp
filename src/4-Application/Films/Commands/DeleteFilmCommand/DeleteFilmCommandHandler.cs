using AutoMapper;
using CRUDPOC.Application.Common.Exceptions;
using CRUDPOC.Application.Common.Helper;
using CRUDPOC.Domain.models;
using CRUDPOC.Shared.Dto;
using CRUDPOC.Shared.Helper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDPOC.Application.Films.Commands.DeleteFilmCommand
{
    public class DeleteFilmCommandHandler : IRequestCommandHandlerWrapper<DeleteFilmCommand, FilmDto>
    {
        private readonly IFilmsApi _filmApi;
        private readonly IMapper _mapper;

        public DeleteFilmCommandHandler(IFilmsApi filmApi, IMapper mapper)
        {
            _filmApi = filmApi;
            _mapper = mapper;
        }

        public async Task<ServiceResult<FilmDto>> Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
        {
            Film filmToDelete = await _filmApi.GetById(request.Id);
            if (filmToDelete == null)
            {
                throw new NotFoundException(nameof(FilmDto), request.Id);
            }
            await _filmApi.Remove(request.Id);

            return ServiceResult.Success(_mapper.Map<FilmDto>(filmToDelete));
        }
    }
}