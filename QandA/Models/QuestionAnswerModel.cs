namespace QandA.Models
{
    public class QuestionAnswerModel
    {
        public Question Question { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
