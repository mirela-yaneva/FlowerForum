using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FlowersForum.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public Task CreateAsync(Topic model)
            => _topicRepository.CreateAsync(model);

        public Task<PaginationResult<Topic>> GetAllAsync(int? pageNumber, int? pageSize)
            => _topicRepository.GetAllAsync(pageNumber.Value, pageSize.Value);

        public Task<Topic> GetByIdAsync(Guid id)
        => _topicRepository.GetByIdAsync(id);

        public Task UpdateAsync(Topic model)
            => (_topicRepository.UpdateAsync(model));

        public Task DeleteAsync(Guid id)
            => (_topicRepository.DeleteAsync(id));
    }
}
