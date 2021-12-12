using FlowersForum.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowersForum.Data
{
    public class FlowersForumDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
