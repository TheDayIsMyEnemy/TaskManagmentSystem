using System;
using TaskManagmentSystem.Common.Mappings;
using TaskManagmentSystem.Core.Entities;

namespace TaskManagmentSystem.Core.DTOs
{
    public class TaskDto : IMapFrom<AppTask>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TaskPriority Priority { get; set; }

        public TaskStatus Status { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime Created { get; set; }
    }
}
