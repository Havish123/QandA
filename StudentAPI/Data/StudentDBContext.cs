using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Data
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options):base(options)
        {
            Database.EnsureCreated();

        }
        public DbSet<Student> Students { get; set; }
    }
}
