using CRUDPOC.Shared.Helper;
using MediatR;

namespace CRUDPOC.Application.Common.Helper
{
    public interface ICommandWrapper<T> : IRequest<ServiceResult<T>>
    {
    }

    public interface IRequestCommandHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, ServiceResult<TOut>> where TIn : ICommandWrapper<TOut>
    {
    }
}