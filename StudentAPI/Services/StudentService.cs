using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Models;

namespace StudentAPI.Services
{
    public interface IStudentService
    {
        public  Task<Student> Get(int id);
        public Task<Student> Create(Student student);
        public Task Delete(int id);
        public Task<IEnumerable<Student>> Get();
        public Task Update(Student student);



    }
    public class StudentService : IStudentService
    {
        private readonly StudentDBContext _context;
        public StudentService(StudentDBContext context)
        {
            _context = context;
        }
        public async Task<Student> Create(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Student> Get(int id)
        {
           var student=await _context.Students.FindAsync(id);
            if(student != null)
            {
                return student;
            }
            return null;
        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
