using Core.Security.Dtos;
using Core.Security.JWT;
using KodlamaIoDevs.Application.Features.Auth.Commands.Login;
using KodlamaIoDevs.Application.Features.Auth.Commands.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIoDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            AccessToken accessToken = await _mediator.Send(new RegisterCommand() { UserForRegisterDto = userForRegisterDto});
            return Ok(accessToken);
        } 
        
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            AccessToken accessToken = await _mediator.Send(new LoginCommand() { UserForLoginDto = userForLoginDto});
            return Ok(accessToken);
        } 
    }
}
