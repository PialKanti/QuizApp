using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Entities;

namespace QuizApp.Data
{
    public class QuizAppContext : IdentityDbContext<ApplicationUser>
    {
        public QuizAppContext(DbContextOptions<QuizAppContext> options) : base(options) { }

        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedDefaultAdminUser(builder);
            SeedRoles(builder);
            SeedDefaultAdminUserRole(builder);
        }

        private void SeedDefaultAdminUser(ModelBuilder builder)
        {
            ApplicationUser user = new ApplicationUser
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                FirstName = "Default",
                LastName = "Admin",
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "admin@test.com",
                NormalizedEmail = "admin@test.com".ToUpper(),
                LockoutEnabled = false,
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "admin123");

            builder.Entity<ApplicationUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                 new IdentityRole
                 { 
                     Id = "fab4fac1-c546-41de-aebc-a14da6895711", 
                     Name = "Admin", 
                     ConcurrencyStamp = "1", 
                     NormalizedName = "Admin" 
                 },
                 new IdentityRole
                 { 
                     Id = "c7b013f0-5201-4317-abd8-c211f91b7330", 
                     Name = "Participant", 
                     ConcurrencyStamp = "2", 
                     NormalizedName = "Participant"
                 });
        }

        private void SeedDefaultAdminUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> {
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711"
                });
        }
    }
}
