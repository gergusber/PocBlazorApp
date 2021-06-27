using CRUDPOC.Application.Developers.Queries.GetAllDevelopers;
using CRUDPOC.Application.Developers.Queries.GetDeveloperById;
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
        public async Task GetAll_InputIsNull_ReturnTrueAsync()
        {
            MediatorMock.Setup(x => x.Send(It.IsAny<GetAllDevelopersQuery>(), new System.Threading.CancellationToken())).ReturnsAsync(new Shared.Helper.ServiceResult<System.Collections.Generic.IEnumerable<Shared.Dto.DeveloperDto>>());
            var developerController = new DeveloperController(MediatorMock.Object);
            var result = await developerController.Get();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GETsingleDev_InputIs1_ReturnTrueAsync()
        {
            MediatorMock.Setup(x => x.Send(It.IsAny<GetDeveloperByIdQuery>(), new System.Threading.CancellationToken())).ReturnsAsync(new Shared.Helper.ServiceResult<Shared.Dto.DeveloperDto>());
            var developerController = new DeveloperController(MediatorMock.Object);
            var result = await developerController.Get(1);

            Assert.NotNull(result);
        }
    }
}