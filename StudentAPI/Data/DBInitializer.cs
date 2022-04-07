using StudentAPI.Models;

namespace StudentAPI.Data
{

    public static class DBInitializer
    {
        
        public static void Initializer(StudentDBContext context)
        {
            if (context.Students.Any())
            {
                return;
            }
            List<Student> students = new List<Student>()
            {
                new Student
                {
                    Name="Dharani",
                    Age=22,
                },new Student
                {
                    Name="Deepakraj",
                    Age=32,
                },new Student
                {
                    Name="DeepakSuriya",
                    Age=34,
                },new Student
                {
                    Name="Sudharshan",
                    Age=20,
                }
            };
            context.Students.AddRange(students);
            context.SaveChanges();

           
        }

    }
}
