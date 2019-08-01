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

        [Required]
        public TaskPriority Priority { get; set; }

        [Required]
        public TaskState Status { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }
    }
}
