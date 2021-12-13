using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
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

        public Task CreateAsync(RuleSectionModel model)
        {
            return _ruleSectionRepository.CreateAsync(model);
        }

        public Task<List<RuleSectionModel>> GetAllAsync(int? offset, int? limit)
        {
            return _ruleSectionRepository.GetAllAsync(offset, limit);
        }

        public Task<RuleSectionModel> GetByIdAsync(Guid id)
        {
            return _ruleSectionRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(RuleSectionModel model)
        {
            return _ruleSectionRepository.UpdateAsync(model);
        }

        public Task DeleteAsync(Guid id)
        {
            return _ruleSectionRepository.DeleteAsync(id);
        }
    }
}
