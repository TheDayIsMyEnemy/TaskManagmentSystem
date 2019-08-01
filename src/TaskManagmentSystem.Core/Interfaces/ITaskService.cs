using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.DTOs;
using TaskManagmentSystem.Core.Entities;

namespace TaskManagmentSystem.Core.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> GetByIdAsync(int id);
        Task<int> CreateTaskAsync(string title, string description, TaskState state, TaskPriority priority, DateTime? dueDate);
        Task<int> GetTaskCountAsync();
        Task<IEnumerable<TaskDto>> List(int page, int pageSize);
        Task<IList<TaskDto>> SearchAsync(int page, int pageSize, string searchText);
        Task<IList<TaskDto>> SearchAsync(int page,
                                 int pageSize,
                                 string searchText,
                                 bool title,
                                 bool description,
                                 TaskPriority priority,
                                 TaskState state,
                                 DateTime? dueDate,
                                 DateTime? created,
                                 int? creatorId);


    }
}
