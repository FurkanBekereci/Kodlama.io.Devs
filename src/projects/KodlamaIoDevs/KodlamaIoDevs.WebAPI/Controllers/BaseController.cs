using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIoDevs.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        public IMediator? Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
        public IMediator _mediator { get; set; }
    }
}
