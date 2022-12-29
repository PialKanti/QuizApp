using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Entities;

namespace QuizApp.Data
{
    public class QuizAppContext : IdentityDbContext<User>
    {
        public QuizAppContext(DbContextOptions<QuizAppContext> options) : base(options) { }
    }
}
