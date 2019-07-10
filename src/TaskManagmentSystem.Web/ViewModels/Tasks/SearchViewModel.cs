using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.DTOs;

namespace TaskManagmentSystem.Web.ViewModels.Tasks
{
    public class SearchViewModel
    {
        public string Q { get; set; }

        public bool Title { get; set; }

        public bool Description { get; set; }

        public IList<TaskDto> Tasks { get; set; }
    }
}
