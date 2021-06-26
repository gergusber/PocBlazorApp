using MediatR;
using Moq;

namespace CRUDPOC.Test.API
{
    public class BaseControllerMock
    {
       protected internal Mock<IMediator> MediatorMock;
    }
}