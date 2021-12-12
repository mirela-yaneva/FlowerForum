using FlowersForum.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions
{
    public interface IBaseRepository<TDto>
        where TDto : BaseDto
    {
        public Task<TDto> CreateAsync(TDto dto);
        public Task<TDto> GetByIdAsync(Guid id);
        public Task<List<TDto>> GetAllAsync(int? offset, int? limit, Expression<Func<TDto, bool>> filter = null);
        public Task UpdateAsync(TDto dto);
        public Task DeleteAsync(Guid id);
    }
}
