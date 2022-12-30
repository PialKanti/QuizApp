using System.ComponentModel.DataAnnotations;

namespace QuizApp.Dtos
{
    public class QuizCreateDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public IEnumerable<int>? SelectedQuestionIds { get; set; }
    }
}
