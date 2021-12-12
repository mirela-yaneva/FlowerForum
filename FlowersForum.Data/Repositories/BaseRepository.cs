using AutoMapper;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Abstractions;
using FlowersForum.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlowersForum.Data.Repositories
{
    public abstract class BaseRepository<TDto, TEntity> : IBaseRepository<TDto>
        where TDto : BaseDto
        where TEntity : BaseEntity
    {
        protected readonly FlowersForumDbContext _dbContext;
        protected DbSet<TEntity> entities;
        protected IMapper _mapper;

        protected BaseRepository(FlowersForumDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            entities = _dbContext.Set<TEntity>();
        }

        public async Task<TDto> CreateAsync(TDto dto)
        {
            dto.Id = Guid.NewGuid();
            TEntity entity = _mapper.Map<TEntity>(dto);

            await entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);

        }

        public async Task<List<TDto>> GetAllAsync(int? offset, int? limit, Expression<Func<TDto, bool>> filter = null)
        {
            var query = entities.AsQueryable();

            if (filter != null)
            {
                var filterDb = _mapper.Map<Expression<Func<TEntity, bool>>>(filter);
                query = query.Where(filterDb);
            }

            if (offset != null)
            {
                query = query.Skip(offset.Value);
            }
            if (limit != null)
            {
                query = query.Take(limit.Value);
            }

            return await _mapper.ProjectTo<TDto>(query).ToListAsync();
        }

        public async Task<TDto> GetByIdAsync(Guid id)
        {
            TEntity entity = await entities
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            var dto = _mapper.Map<TDto>(entity);

            return dto;
        }

        public async Task UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            TEntity entity = await entities
               .FirstOrDefaultAsync(e => e.Id == id);

            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
