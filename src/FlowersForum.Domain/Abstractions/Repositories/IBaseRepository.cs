using FlowersForum.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Repositories
{
    public interface IBaseRepository<TModel>
        where TModel : BaseModel
    {
        public Task<TModel> CreateAsync(TModel dto);
        public Task<TModel> GetByIdAsync(Guid id);
        public Task<(List<TModel>, int)> GetAllAsync(int? offset, int? limit, Expression<Func<TModel, bool>> filter = null);
        public Task UpdateAsync(TModel dto);
        public Task DeleteAsync(Guid id);
    }
}
