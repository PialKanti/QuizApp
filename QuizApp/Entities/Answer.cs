namespace QuizApp.Entities
{
    public class Answer : BaseEntity
    {
        public Question Question { get; set; }
        public Option Option { get; set; }
    }
}
