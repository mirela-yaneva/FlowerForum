using FlowersForum.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowersForum.Data
{
    public class FlowersForumDbContext : DbContext
    {
        public DbSet<Section> Sections { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<RuleSection> RuleSections { get; set; }

        public FlowersForumDbContext(DbContextOptions<FlowersForumDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Section>()
                        .HasOne(x => x.Parent)
                        .WithMany(x => x.Subsections)
                        .HasForeignKey(x => x.ParentId);

            modelBuilder.Entity<Topic>()
                 .HasOne(x => x.Parent)
                 .WithMany(x => x.Subtopics)
                 .HasForeignKey(x => x.ParentId);

            modelBuilder.Entity<RuleSection>()
                        .HasOne(x => x.Parent)
                        .WithMany(x => x.Rules)
                        .HasForeignKey(x => x.ParentId);
        }
    }
}
