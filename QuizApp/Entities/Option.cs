using System.ComponentModel.DataAnnotations;

namespace QuizApp.Entities
{
    public class Option : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
