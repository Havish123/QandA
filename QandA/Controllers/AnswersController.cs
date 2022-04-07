#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QandA.Data;
using QandA.Models;
using QandA.Services;

namespace QandA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _services;

        public AnswersController(IAnswerService service)
        {
            _services = service;
        }

        // GET: api/Answers
        [HttpGet]
        public async Task<IEnumerable<Answer>> GetAnswers()
        {
            return await _services.Get();
        }

        // GET: api/Answers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswer(int id)
        {
            return await _services.Get(id);
        }

        // PUT: api/Answers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswer(int id, Answer answer)
        {
            if (id != answer.AnswerID)
            {
                return BadRequest();
            }
            await _services.Update(answer);
            return NoContent();
        }

        // POST: api/Answers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer(Answer answer)
        {
            var newAns = await _services.Create(answer);
            return CreatedAtAction(nameof(GetAnswer), new { id = newAns.AnswerID }, newAns);
        }

        // DELETE: api/Answers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var question = await _services.Get(id);
            if (question == null)
            {
                return NotFound();
            }
            await _services.Delete(id);
            return NoContent();
        }

        //private bool AnswerExists(int id)
        //{
        //    return _context.Answers.Any(e => e.AnswerID == id);
        //}
    }
}
