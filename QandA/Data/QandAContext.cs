using Microsoft.EntityFrameworkCore;
using QandA.Models;

namespace QandA.Data
{
    public class QandAContext:DbContext
    {
        public QandAContext(DbContextOptions<QandAContext> options) : base(options)
        {
            Database.EnsureCreated();

        }
       
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<Answer>().ToTable("Answer");
        }

    }
}
