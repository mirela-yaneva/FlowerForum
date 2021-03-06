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

        public Task CreateAsync(Section model)
             => _sectionRepository.CreateAsync(model);

        public Task<(List<Section>, int)> GetAllAsync(int? offset, int? limit)
            => _sectionRepository.GetAllAsync(offset, limit);

        public Task<Section> GetByIdAsync(Guid id)
            => _sectionRepository.GetByIdAsync(id);

        public Task UpdateAsync(Section model)
            => _sectionRepository.UpdateAsync(model);

        public Task DeleteAsync(Guid id)
            => (_sectionRepository.DeleteAsync(id));
    }
}
