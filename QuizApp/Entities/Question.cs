using System.ComponentModel.DataAnnotations;

namespace QuizApp.Entities
{
    public class Question : BaseEntity
    {
        [Required]
        [MaxLength(300)]
        public string? Title { get; set; }
        [Required]
        public List<Option>? Options { get; set; }
    }
}
