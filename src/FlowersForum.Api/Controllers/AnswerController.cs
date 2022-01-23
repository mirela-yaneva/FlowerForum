using AutoMapper;
using FlowersForum.Api.Models;
using FlowersForum.Api.Models.Paginations;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlowersForum.Api.Controllers
{
    [ApiController]
    [Route("answers")]
    [Authorize]
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
        [ProducesResponseType(typeof(PaginationResultVM<AnswerVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(int? offset, int? limit)
        {
            var models = await _answerService.GetAllAsync(offset, limit);
            return Ok(_mapper.Map<PaginationResultVM<AnswerVM>>(models));
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

            var model = _mapper.Map<Answer>(viewModel);
            model.UserId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
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

            var model = _mapper.Map<Answer>(viewModel);
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
