using CRUDPOC.Application.Developers.Queries.GetAllDevelopers;
using CRUDPOC.Server.Controllers;
using MediatR;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CRUDPOC.Test.API
{
    public class DeveloperTests : BaseControllerMock
    {
        public DeveloperTests()
        {
            MediatorMock = new Mock<IMediator>();
        }
        [Fact]
        public async Task IsPrime_InputIs1_ReturnFalseAsync()
        {
            MediatorMock.Setup(x => x.Send(It.IsAny<GetAllDevelopersQuery>(), new System.Threading.CancellationToken())).ReturnsAsync(new Shared.Helper.ServiceResult<System.Collections.Generic.IEnumerable<Shared.Dto.DeveloperDto>>());
            var developerController = new DeveloperController(MediatorMock.Object);
            var result = await developerController.Get();

            Assert.NotNull(result);
        }
    }
}