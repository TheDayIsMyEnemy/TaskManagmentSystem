using System;
using System.Collections.Generic;

namespace TaskManagmentSystem.Core.Entities
{
    public class AppTask : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TaskPriority Priority { get; set; }

        public TaskStatus Status { get; set; } 

        public DateTime? DueDate { get; set; }

        public DateTime Created { get; set; }

        public string CreatorId { get; set; }
        public User Creator { get; set; }

        public string AssigneeId { get; set; }
        public User Assignee { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();

        public List<TaskCategory> Categories { get; set; } = new List<TaskCategory>();

        // add projects
    }
}
