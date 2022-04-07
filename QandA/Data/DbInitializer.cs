using QandA.Models;

namespace QandA.Data
{

    public static class DbInitializer
    {
        public static void Initialize( QandAContext context)
        {


            if (context.Questions.Any() || context.Answers.Any())
            {
                return;   // DB has been seeded
            }

            var questions = new Question[]
            {
                new Question{content="Welcome",title="What is .Net Core?",userName="Havishwaran",created=DateTime.Now},
                new Question{content="Welcome",title="What is .Net Core?",userName="Dharani",created=DateTime.Now},
                new Question{content="Welcome",title="What is .Net Core?",userName="Suwathi",created=DateTime.Now},
            };
            context.Questions.AddRange(questions);
            context.SaveChanges();
            

        }
    }
}
