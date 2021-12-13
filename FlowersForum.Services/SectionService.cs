using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowersForum.Services
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public Task CreateAsync(SectionModel model)
        {
            return _sectionRepository.CreateAsync(model);
        }

        public Task<List<SectionModel>> GetAllAsync(int? offset, int? limit)
        {
            return _sectionRepository.GetAllAsync(offset, limit);
        }

        public Task<SectionModel> GetByIdAsync(Guid id)
        {
            return _sectionRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(SectionModel model)
        {
            return _sectionRepository.UpdateAsync(model);
        }

        public Task DeleteAsync(Guid id)
        {
            return _sectionRepository.DeleteAsync(id);
        }
    }
}
