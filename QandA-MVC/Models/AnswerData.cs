namespace QandA_MVC.Models
{
    public class AnswerData
    {
        public int AnswerID { get; set; }
        public string content { get; set; }
        public string userName { get; set; }
        public DateTime created { get; set; }
        public int QuestionID { get; set; }

    }
}
