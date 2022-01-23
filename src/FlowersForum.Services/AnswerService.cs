using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FlowersForum.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public Task CreateAsync(Answer model)
            => _answerRepository.CreateAsync(model);

        public Task<PaginationResult<Answer>> GetAllAsync(int? pageNumber, int? pageSize)
            => _answerRepository.GetAllAsync(pageNumber.Value, pageSize.Value);

        public Task<Answer> GetByIdAsync(Guid id)
            => _answerRepository.GetByIdAsync(id);

        public Task UpdateAsync(Answer model)
            => _answerRepository.UpdateAsync(model);

        public Task DeleteAsync(Guid id)
            => (_answerRepository.DeleteAsync(id));
    }
}
