using AutoMapper;
using FlowersForum.Api.Models.Users;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlowersForum.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthenticationController(IUserService userService , IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpPost("register-admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<User>(viewModel);

            model.Role = Domain.Enums.Role.Admin;

            await _userService.CreateAsync(model);
            return NoContent();
        }

        [HttpPost("register-user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _mapper.Map<User>(viewModel);

            model.Role = Domain.Enums.Role.User;

            await _userService.CreateAsync(model);
            return NoContent();
        }
    }
}
