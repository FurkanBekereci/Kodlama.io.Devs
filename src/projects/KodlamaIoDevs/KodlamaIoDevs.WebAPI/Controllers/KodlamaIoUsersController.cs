using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Commands.CreateKodlamaIoUser;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Commands.DeleteKodlamaIoUser;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Commands.UpdateKodlamaIoUser;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Dtos;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Queries.GetByUserIdKodlamaIoUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIoDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KodlamaIoUsersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int UserId)
        {
            KodlamaIoUserGetByUserIdDto kodlamaIoUserGetByUserIdDto = await _mediator.Send(new GetByUserIdKodlamaIoUserQuery { UserId = UserId });

            return Ok(kodlamaIoUserGetByUserIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromQuery] int UserId, [FromBody] string GithubUrl)
        {
            CreatedKodlamaIoUserDto createdKodlamaIoUserDto = await _mediator.Send(new CreateKodlamaIoUserCommand { UserId = UserId , GithubUrl = GithubUrl});

            return Created("",createdKodlamaIoUserDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int UserId, [FromBody] string GithubUrl)
        {
            UpdatedKodlamaIoUserDto updatedKodlamaIoUserDto = await _mediator.Send(new UpdateKodlamaIoUserCommand { UserId = UserId , GithubUrl = GithubUrl});

            return Ok(updatedKodlamaIoUserDto);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int UserId)
        {
            DeletedKodlamaIoUserDto deletedKodlamaIoUserDto = await _mediator.Send(new DeleteKodlamaIoUserCommand { UserId = UserId});

            return Ok(deletedKodlamaIoUserDto);
        }
    }
}
