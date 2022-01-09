using AutoMapper;
using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Constants;
using FlowersForum.Domain.Exceptions;
using FlowersForum.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FlowersForum.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHasherService _hasherService;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, 
            IHasherService hasherService, 
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _hasherService = hasherService;
            _jwtService = jwtService;
        }

        public Task CreateAsync(User model)
            => _userRepository.CreateAsync(model);

        public Task<PaginationResult<User>> GetAllAsync(int? offset, int? limit)
            => _userRepository.GetAllAsync((offset.Value - 1) * limit.Value, limit.Value);

        public Task<User> GetByIdAsync(Guid id)
            => _userRepository.GetByIdAsync(id);

        public Task UpdateAsync(User model)
            => _userRepository.UpdateAsync(model);

        public Task DeleteAsync(Guid id)
            => (_userRepository.DeleteAsync(id));

        public async Task<LoginResponse> LoginAsync(string userName, string password)
        {
            User user = await _userRepository.GetByUsername(userName);
            if (user == null || !_hasherService.VerifyHashedPassword(password, user.Password, user.Salt))
            {
                throw new AppException(StringConstants.InvalidUserOrPass);
            }
            var token = _jwtService.GenerateJsonWebToken(user.Role, user.Id);

            return new LoginResponse
            {
                JwtToken = token
            };
        }
    }
}
