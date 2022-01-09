using AutoMapper;
using FlowersForum.Data.Entities;
using FlowersForum.Domain.Abstractions.Repositories;
using FlowersForum.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FlowersForum.Data.Repositories
{
    public class UserRepository : BaseRepository<User, UserEntity>, IUserRepository
    {
        public UserRepository(FlowersForumDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public Task<User> GetByUsername(string username)
            =>  _mapper.ProjectTo<User>(entities.Where(x => x.Username == username)).FirstOrDefaultAsync();
    }
}
