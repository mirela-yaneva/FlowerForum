using AutoMapper;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlowersForum.Data.Repositories
{
    public abstract class BaseRepository<TModel, T> : IBaseRepository<TModel>
        where TModel : BaseModel
        where T : BaseEntity
    {
        protected readonly FlowersForumDbContext _dbContext;
        protected DbSet<T> entities;
        protected IMapper _mapper;

        protected BaseRepository(FlowersForumDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            entities = _dbContext.Set<T>();
        }

        public async Task<TModel> CreateAsync(TModel model)
        {
            model.Id = Guid.NewGuid();
            T entity = _mapper.Map<T>(model);

            await entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TModel>(entity);

        }

        public async Task<List<TModel>> GetAllAsync(int? offset, int? limit, Expression<Func<TModel, bool>> filter = null)
        {
            var query = entities.AsQueryable();

            if (filter != null)
            {
                var filterDb = _mapper.Map<Expression<Func<T, bool>>>(filter);
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

            return await _mapper.ProjectTo<TModel>(query).ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(Guid id)
        {
            T entity = await entities
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            var dto = _mapper.Map<TModel>(entity);

            return dto;
        }

        public async Task UpdateAsync(TModel dto)
        {
            var entity = _mapper.Map<T>(dto);

            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            T entity = await entities
               .FirstOrDefaultAsync(e => e.Id == id);

            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
