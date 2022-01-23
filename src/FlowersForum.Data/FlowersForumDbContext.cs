using FlowersForum.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowersForum.Data
{
    public class FlowersForumDbContext : DbContext
    {
        public DbSet<SectionEntity> Sections { get; set; }

        public DbSet<TopicEntity> Topics { get; set; }

        public DbSet<AnswerEntity> Answers { get; set; }

        public DbSet<RuleSectionEntity> RuleSections { get; set; }

        public FlowersForumDbContext(DbContextOptions<FlowersForumDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SectionEntity>()
                        .HasOne(x => x.Parent)
                        .WithMany(x => x.Subsections)
                        .HasForeignKey(x => x.ParentId);

            modelBuilder.Entity<TopicEntity>()
                 .HasOne(x => x.Parent)
                 .WithMany(x => x.Subtopics)
                 .HasForeignKey(x => x.ParentId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RuleSectionEntity>()
                        .HasOne(x => x.Parent)
                        .WithMany(x => x.Rules)
                        .HasForeignKey(x => x.ParentId);
        }
    }
}
