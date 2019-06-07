using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TaskManagmentSystem.Core.Entities
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthdate { get; set; }

        public List<AppTask> CreatedTasks { get; set; } = new List<AppTask>();

        public List<AppTask> AssignedTasks { get; set; } = new List<AppTask>();

        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
