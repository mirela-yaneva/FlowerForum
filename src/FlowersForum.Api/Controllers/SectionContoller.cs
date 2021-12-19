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
    [Route("sections")]
    public class SectionContoller : ControllerBase
    {
        private readonly ISectionService _sectionService;
        private readonly IMapper _mapper;

        public SectionContoller(ISectionService sectionService, IMapper mapper)
        {
            _sectionService = sectionService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetSections")]
        public async Task<IActionResult> GetAllAsync(int? offset, int? limit)
        {
            var (items, count) = await _sectionService.GetAllAsync(offset, limit);

            return Ok(new
            {
                Items = _mapper.Map<List<SectionVM>>(items),
                Count = count
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var model = await _sectionService.GetByIdAsync(id);
            return Ok(_mapper.Map<SectionVM>(model));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SectionVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<Section>(viewModel);
            await _sectionService.CreateAsync(model);
            return CreatedAtRoute("GetActivities", viewModel);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] SectionVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<Section>(viewModel);
            await _sectionService.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
        {
            await _sectionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
