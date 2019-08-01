using System.Collections.Generic;
using TaskManagmentSystem.Core.DTOs;
using TaskManagmentSystem.Core.Entities;

namespace TaskManagmentSystem.Web.ViewModels.Search
{
    public class SearchViewModel
    {
        public string Query { get; set; }
        public IList<TaskDto> Tasks { get; set; }
        public bool Title { get; set; } = true;
        public bool Description { get; set; } = true;
        public TaskPriority TaskPriority { get; set; } = TaskPriority.Critical;
        public TaskState TaskState { get; set; } = TaskState.Active;

    }
}
