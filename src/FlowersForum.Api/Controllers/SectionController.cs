using AutoMapper;
using FlowersForum.Api.Models;
using FlowersForum.Api.Models.Paginations;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Constants;
using FlowersForum.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FlowersForum.Api.Controllers
{
    [ApiController]
    [Route("sections")]
    [Authorize(Policy = StringConstants.AdminPolicy)]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;
        private readonly IMapper _mapper;

        public SectionController(ISectionService sectionService, IMapper mapper)
        {
            _sectionService = sectionService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetSections")]
        [ProducesResponseType(typeof(PaginationResultVM<SectionVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(int? offset, int? limit)
        {
            var models = await _sectionService.GetAllAsync(offset, limit);
            return Ok(_mapper.Map<PaginationResultVM<SectionVM>>(models));
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
