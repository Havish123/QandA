using Microsoft.EntityFrameworkCore;
using QandA.Data;
using QandA.Models;
using System.Linq;

namespace QandA.Services
{
    public interface IQuestionService
    {
        public Task<Question> Get(int id);
        public Task<Question> Create(Question question);
        public Task Delete(int id);
        public Task<IEnumerable<Question>> Get();
        public Task Update(Question question);



    }
    public class QuestionService : IQuestionService
    {
        private readonly QandAContext _context;
        public QuestionService(QandAContext context)
        {
            _context = context;
        }

        public async Task<Question> Create(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Question> Get(int id)
        {
            Question question = await _context.Questions.FindAsync(id); 
            
            question.Answers = (from answer in _context.Answers where question.QuestionID == answer.QuestionID select answer).ToList();
            return question;
        }
        public async Task Delete(int id)
        {
            var questToDel = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(questToDel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> Get()
        {
            var questions= await _context.Questions.ToListAsync();
            questions.ForEach(q => q.Answers = (from answer in _context.Answers where q.QuestionID == answer.QuestionID select answer).ToList());
            return questions;
        }


        public async Task Update(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
