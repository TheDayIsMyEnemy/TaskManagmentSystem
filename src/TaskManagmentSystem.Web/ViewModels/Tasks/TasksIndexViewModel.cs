using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.DTOs;

namespace TaskManagmentSystem.Web.ViewModels.Tasks
{
    public class TasksIndexViewModel
    {
        public IEnumerable<TaskDto> Tasks { get; set; }

        public PaginationViewModel Pagination { get; set; }

        public SearchViewModel Search { get; set; }
    }
}
