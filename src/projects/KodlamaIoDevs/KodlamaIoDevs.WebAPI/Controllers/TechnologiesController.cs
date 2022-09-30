using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaIoDevs.Application.Features.Technologies.Commands.DeleteTechnology;
using KodlamaIoDevs.Application.Features.Technologies.Commands.UpdateTechnology;
using KodlamaIoDevs.Application.Features.Technologies.Dtos;
using KodlamaIoDevs.Application.Features.Technologies.Models;
using KodlamaIoDevs.Application.Features.Technologies.Queries.GetByIdTechnology;
using KodlamaIoDevs.Application.Features.Technologies.Queries.GetListTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIoDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {


        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
            TechnologyGetByIdDto technologyGetByIdDto = await _mediator.Send(getByIdTechnologyQuery);

            return Ok(technologyGetByIdDto);
        }
        
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new() { PageRequest = pageRequest };
            TechnologyListModel technologyListModel = await _mediator.Send(getListTechnologyQuery);

            return Ok(technologyListModel);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            
            CreatedTechnologyDto createdTechnologyDto = await _mediator.Send(createTechnologyCommand);

            return Created("",createdTechnologyDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            updateTechnologyCommand.Id = id;
            UpdatedTechnologyDto updatedTechnologyDto = await _mediator.Send(updateTechnologyCommand);

            return Ok(updatedTechnologyDto);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto deletedTechnologyDto = await _mediator.Send(deleteTechnologyCommand);

            return Ok(deletedTechnologyDto);
        }
    }
}
