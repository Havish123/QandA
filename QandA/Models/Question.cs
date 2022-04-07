namespace QandA.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string userName { get; set; }
        public DateTime created { get; set; }

        public ICollection<Answer> Answers { get; set; }

    }
    //public class Student
    //{
    //    public int ID { get; set; }
    //    public string LastName { get; set; }
    //    public string FirstMidName { get; set; }
    //    public DateTime EnrollmentDate { get; set; }

    //    public ICollection<Enrollment> Enrollments { get; set; }
    //}

}
//export interface QuestionData
//{
//    questionId: number;
//  title: string;
//  content: string;
//  userName: string;
//  created: Date;
//  answers: AnswerData[];
//}
