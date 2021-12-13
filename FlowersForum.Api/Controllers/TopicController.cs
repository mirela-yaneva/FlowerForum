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
    [Route("topics")]
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
        public async Task<IActionResult> GetAllAsync(int? offset, int? limit)
        {
            var models = await _topicService.GetAllAsync(offset, limit);
            return Ok(_mapper.Map<List<TopicVM>>(models));
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

            var model = _mapper.Map<TopicModel>(viewModel);
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

            var model = _mapper.Map<TopicModel>(viewModel);
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
