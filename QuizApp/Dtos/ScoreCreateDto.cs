using System.ComponentModel.DataAnnotations;

namespace QuizApp.Dtos
{
    public class ScoreCreateDto
    {
        [Required]
        public IEnumerable<QuestionAnswerDto>? AnsweredQuestions { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public int QuizId { get; set; }
    }
}
