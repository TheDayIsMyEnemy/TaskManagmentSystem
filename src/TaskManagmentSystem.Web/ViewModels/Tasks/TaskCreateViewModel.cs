using System;
using System.ComponentModel.DataAnnotations;
using TaskManagmentSystem.Core.Entities;

namespace TaskManagmentSystem.Web.ViewModels.Tasks
{
    public class TaskCreateViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        public TaskPriority Priority { get; set; }

        public TaskStatus Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
    }
}
