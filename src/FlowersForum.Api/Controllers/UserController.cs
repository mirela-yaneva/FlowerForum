using AutoMapper;
using FlowersForum.Api.Models.Paginations;
using FlowersForum.Api.Models.Users;
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
    [Route("api/users")]
    [Authorize(Policy = StringConstants.AdminPolicy)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetUsers")]
        [ProducesResponseType(typeof(PaginationResultVM<UserVM>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(int? pageNumber, int? pageSize)
        {
            var models = await _userService.GetAllAsync(pageNumber, pageSize);
            return Ok(_mapper.Map<PaginationResultVM<UserVM>>(models));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserVM), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var model = await _userService.GetByIdAsync(id);
            return Ok(_mapper.Map<UserVM>(model));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAsync([FromBody] UserVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<User>(viewModel);

            await _userService.UpdateAsync(model);
            return NoContent();
        }
        
        [HttpDelete("{id}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
