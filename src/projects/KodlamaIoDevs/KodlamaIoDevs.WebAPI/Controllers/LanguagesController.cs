﻿using Core.Application.Requests;
using KodlamaIoDevs.Application.Features.Languages.Commands.CreateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Commands.DeleteLanguage;
using KodlamaIoDevs.Application.Features.Languages.Commands.UpdateLanguage;
using KodlamaIoDevs.Application.Features.Languages.Dtos;
using KodlamaIoDevs.Application.Features.Languages.Models;
using KodlamaIoDevs.Application.Features.Languages.Queries.GetByIdLanguage;
using KodlamaIoDevs.Application.Features.Languages.Queries.GetListLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIoDevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreatedLanguageDto result = await Mediator!.Send(createLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator!.Send(getListLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            LanguageGetByIdDto LanguageGetByIdDto = await Mediator!.Send(getByIdLanguageQuery);
            return Ok(LanguageGetByIdDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            updateLanguageCommand.Id = id;
            UpdatedLanguageDto updatedLanguageDto = await _mediator.Send(updateLanguageCommand);

            return Ok(updatedLanguageDto);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteLanguageCommand deleteLanguageCommand)
        {
            DeletedLanguageDto deletedLanguageDto = await _mediator.Send(deleteLanguageCommand);

            return Ok(deletedLanguageDto);
        }
    }
}
