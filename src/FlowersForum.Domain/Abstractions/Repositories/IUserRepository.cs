using FlowersForum.Domain.Models;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Abstractions.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByEmail(string username);
    }
}
