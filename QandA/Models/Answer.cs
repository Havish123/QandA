namespace QandA.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public string content { get; set; }
        public string userName { get; set; }
        public DateTime created { get; set; }
        public int QuestionID { get; set; }
        
    }
    
}


//export interface AnswerData
//{
//    answerId: number;
//  content: string;
//  userName: string;
//  created: Date;
//}