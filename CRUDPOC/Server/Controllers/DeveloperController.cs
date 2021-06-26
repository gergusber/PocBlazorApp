using CRUDPOC.Application.Developers.Commands.CreateDeveloperCommand;
using CRUDPOC.Application.Developers.Queries.GetAllDevelopers;
using CRUDPOC.Application.Developers.Queries.GetDeveloperById;
using CRUDPOC.Shared.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CRUDPOC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase// : BaseController
    {
        private IMediator Mediator;

        public DeveloperController(IMediator mediator)
        {
            Mediator = mediator;
        }
        //protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new GetAllDevelopersQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await Mediator.Send(new GetDeveloperByIdQuery { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DeveloperDto developer)
        {
            var response = await Mediator.Send(new CreateDeveloperCommand { developer = developer });

            return CreatedAtAction(nameof(Post), response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(DeveloperDto developer)
        {
            var response = await Mediator.Send(new UpdateDeveloperCommand { developer = developer });

            return CreatedAtAction(nameof(Put), response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Mediator.Send(new DeleteDeveloperCommand { Id = id });

            return CreatedAtAction(nameof(Delete), response);
        }
    }
}