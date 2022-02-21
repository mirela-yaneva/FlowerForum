using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FlowersForum.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHasherService _hasherService;

        public UserService(IUserRepository userRepository, 
            IHasherService hasherService)
        {
            _userRepository = userRepository;
            _hasherService = hasherService;
        }

        public async Task CreateAsync(User model)
        {
            await _userRepository.CreateAsync(model);
        }

        public Task<PaginationResult<User>> GetAllAsync(int? pageNumber, int? pageSize)
            => _userRepository.GetAllAsync(pageNumber.Value,pageSize.Value);

        public Task<User> GetByIdAsync(Guid id)
            => _userRepository.GetByIdAsync(id);

        public Task UpdateAsync(User model)
            => _userRepository.UpdateAsync(model);

        public Task DeleteAsync(Guid id)
            => (_userRepository.DeleteAsync(id));

       
    }
}
