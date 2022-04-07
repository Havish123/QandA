namespace QandA_MVC.Models
{
    public class QuestionData
    {
        public int QuestionID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string userName { get; set; }
        public DateTime created { get; set; }

        public ICollection<AnswerData> Answers { get; set; }

    }
}
