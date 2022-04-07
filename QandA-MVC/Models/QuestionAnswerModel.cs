namespace QandA_MVC.Models
{
    public class QuestionAnswerModel
    {
        public QuestionData QuestionData { get; set; }
        public ICollection<AnswerData> Answers { get; set; }
    }
}
