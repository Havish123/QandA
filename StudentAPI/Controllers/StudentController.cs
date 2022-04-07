using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService service)
        {
            _studentService = service;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await _studentService.Get();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            return await _studentService.Get(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody] Student student)
        {
            await _studentService.Create(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);

        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            await _studentService.Update(student);
            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await _studentService.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            await _studentService.Delete(id);
            return NoContent();
        }
    }
}
