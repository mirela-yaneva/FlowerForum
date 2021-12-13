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
    [Route("rule-sections")]
    public class RuleSectionController : ControllerBase
    {
        private readonly IRuleSectionService _ruleSectionService;
        private readonly IMapper _mapper;

        public RuleSectionController(IRuleSectionService ruleSectionService, IMapper mapper)
        {
            _ruleSectionService = ruleSectionService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRuleSections")]
        public async Task<IActionResult> GetAllAsync(int? offset, int? limit)
        {
            var models = await _ruleSectionService.GetAllAsync(offset, limit);
            return Ok(_mapper.Map<List<RuleSectionVM>>(models));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var model = await _ruleSectionService.GetByIdAsync(id);
            return Ok(_mapper.Map<RuleSectionVM>(model));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RuleSectionVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<RuleSectionModel>(viewModel);
            await _ruleSectionService.CreateAsync(model);
            return CreatedAtRoute("GetActivities", viewModel);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] RuleSectionVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<RuleSectionModel>(viewModel);
            await _ruleSectionService.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
        {
            await _ruleSectionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
