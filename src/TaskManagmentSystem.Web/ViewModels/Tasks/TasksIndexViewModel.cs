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

        public PaginationInfoViewModel PaginationInfo { get; set; }

        public SearchInfoViewModel SearchInfo { get; set; } = new SearchInfoViewModel();
    }
}
