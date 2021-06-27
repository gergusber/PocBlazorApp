using CRUDPOC.Shared.Helper;
using MediatR;

namespace CRUDPOC.Application.Common.Helper
{
    public interface IQueryWrapper<T> : IRequest<ServiceResult<T>>
    {
    }

    public interface IRequestQueryHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, ServiceResult<TOut>> where TIn : IQueryWrapper<TOut>
    {
    }
}