﻿using Microsoft.AspNetCore.Identity;

namespace QuizApp.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}