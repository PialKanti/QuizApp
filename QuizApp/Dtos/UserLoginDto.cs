using System.ComponentModel.DataAnnotations;

namespace QuizApp.Dtos
{
    public class UserLoginDto
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
