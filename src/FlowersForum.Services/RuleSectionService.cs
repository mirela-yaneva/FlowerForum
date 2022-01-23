using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FlowersForum.Services
{
    public class RuleSectionService : IRuleSectionService
    {
        private readonly IRuleSectionRepository _ruleSectionRepository;

        public RuleSectionService(IRuleSectionRepository ruleSectionRepository)
        {
            _ruleSectionRepository = ruleSectionRepository;
        }

        public Task CreateAsync(RuleSection model)
            => _ruleSectionRepository.CreateAsync(model);

        public Task<PaginationResult<RuleSection>> GetAllAsync(int? pageNumber, int? pageSize)
            => _ruleSectionRepository.GetAllAsync(pageNumber.Value, pageSize.Value);

        public Task<RuleSection> GetByIdAsync(Guid id)
            => _ruleSectionRepository.GetByIdAsync(id);

        public Task UpdateAsync(RuleSection model)
            => _ruleSectionRepository.UpdateAsync(model);

        public Task DeleteAsync(Guid id)
            => _ruleSectionRepository.DeleteAsync(id);
    }
}
