using AutoMapper;
using FlowersForum.Api.Models;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowersForum.Api.Controllers
{
    [ApiController]
    [Route("answers")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;

        public AnswerController(IAnswerService answerService, IMapper mapper)
        {
            _answerService = answerService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAnswers")]
        public async Task<IActionResult> GetAllAsync(int? offset, int? limit)
        {
            var models = await _answerService.GetAllAsync(offset, limit);
            return Ok(_mapper.Map<List<AnswerVM>>(models));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var model = await _answerService.GetByIdAsync(id);
            return Ok(_mapper.Map<AnswerVM>(model));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AnswerVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<AnswerModel>(viewModel);
            await _answerService.CreateAsync(model);
            return CreatedAtRoute("GetActivities", viewModel);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] AnswerVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<AnswerModel>(viewModel);
            await _answerService.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
        {
            await _answerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
