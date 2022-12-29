using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Entities
{
    public class Question : BaseEntity
    {
        [Required]
        [MaxLength(300)]
        public string? Title { get; set; }
        [Required]
        [Column("TimeLimit")]
        public int? TimeLimitInSeconds { get; set; }
        [Required]
        public List<Option>? Options { get; set; }
    }
}
