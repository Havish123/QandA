#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _services;

        public QuestionsController(IQuestionService context)
        {
            _services = context;
            
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<IEnumerable<Question>> GetQuestions()
        {

            return await _services.Get();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            return await _services.Get(id);
        }

        //// PUT: api/Questions/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.QuestionID)
            {
                return BadRequest();
            }
            await _services.Update(question);
            return NoContent();
        }

        //// POST: api/Questions
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            var newQuest = await _services.Create(question);
            return CreatedAtAction(nameof(GetQuestion), new { id = newQuest.QuestionID }, newQuest);
           
        }

        //// DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _services.Get(id);
            if (question == null)
            {
                return NotFound();
            }
            await _services.Delete(id);
            return NoContent();
        }

        //private bool QuestionExists(int id)
        //{
        //    return _context.Questions.Any(e => e.QuestionID == id);
        //}
    }
}
