using Microsoft.AspNetCore.Identity;

namespace QuizApp.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
