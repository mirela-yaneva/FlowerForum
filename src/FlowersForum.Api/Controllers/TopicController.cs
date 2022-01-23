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
    [Route("topics")]
    [Authorize]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public TopicController(ITopicService topicService, IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetTopics")]
        [ProducesResponseType(typeof(PaginationResultVM<TopicVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(int? offset, int? limit)
        {
            var models = await _topicService.GetAllAsync(offset, limit);
            return Ok(_mapper.Map<PaginationResultVM<TopicVM>>(models));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var model = await _topicService.GetByIdAsync(id);
            return Ok(_mapper.Map<TopicVM>(model));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TopicVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<Topic>(viewModel);
            model.UserId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            await _topicService.CreateAsync(model);
            return CreatedAtRoute("GetActivities", viewModel);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] TopicVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<Topic>(viewModel);
            await _topicService.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
        {
            await _topicService.DeleteAsync(id);
            return NoContent();
        }
    }
}
