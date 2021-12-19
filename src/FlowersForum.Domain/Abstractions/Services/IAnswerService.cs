using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface IAnswerService
    {
        Task CreateAsync(Answer model);
        Task<(List<Answer>, int)> GetAllAsync(int? offset, int? limit);
        Task<Answer> GetByIdAsync(Guid id);
        Task UpdateAsync(Answer model);
        Task DeleteAsync(Guid id);
    }
}
