using Microsoft.EntityFrameworkCore;
using QandA.Data;
using QandA.Models;

namespace QandA.Services
{
    public interface IAnswerService
    {
        public Task<Answer> Get(int id);
        public Task<Answer> Create(Answer question);
        public Task Delete(int id);
        public Task<IEnumerable<Answer>> Get();
        public Task Update(Answer answer);



    }
    public class AnswerService : IAnswerService
    {
        private readonly QandAContext _context;
        public AnswerService(QandAContext context)
        {
            _context = context;
        }

        public async Task<Answer> Create(Answer answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task<Answer> Get(int id)
        {
            Answer answer = await _context.Answers.FindAsync(id);

            //question.Answers = (from answer in _context.Answers where question.QuestionID == answer.QuestionID select answer).ToList();
            return answer;
        }
        public async Task Delete(int id)
        {
            var ansToDel = await _context.Answers.FindAsync(id);
            _context.Answers.Remove(ansToDel);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Answer>> Get()
        {
            var answers = await _context.Answers.ToListAsync();
            //questions.ForEach(q => q.Answers = (from answer in _context.Answers where q.QuestionID == answer.QuestionID select answer).ToList());
            return answers;
        }


        public async Task Update(Answer answer)
        {
            _context.Entry(answer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
