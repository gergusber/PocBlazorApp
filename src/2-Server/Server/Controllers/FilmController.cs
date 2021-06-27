using CRUDPOC.Application.Films.Commands.CreateFilmCommand;
using CRUDPOC.Application.Films.Commands.DeleteFilmCommand;
using CRUDPOC.Application.Films.Commands.UpdateFilmCommand;
using CRUDPOC.Application.Films.Queries.GetAllFilms;
using CRUDPOC.Application.Films.Queries.GetFilmById;
using CRUDPOC.Server.Controllers;
using CRUDPOC.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new GetAllFilmsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await Mediator.Send(new GetFilmByIdQuery { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FilmDto film)
        {
            var response = await Mediator.Send(new CreateFilmCommand { film = film });

            return CreatedAtAction(nameof(Post), response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FilmDto film)
        {
            var response = await Mediator.Send(new UpdateFilmCommand { filmToUpdate = film });

            return CreatedAtAction(nameof(Put), response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await Mediator.Send(new DeleteFilmCommand { Id = id });

            return CreatedAtAction(nameof(Delete), response);
        }
    }
}