using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.DTOs;
using TaskManagmentSystem.Core.Entities;

namespace TaskManagmentSystem.Core.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> GetByIdAsync(int id);
        Task<int> CreateTaskAsync(string title, string description, Entities.TaskStatus status, TaskPriority priority, DateTime? dueDate);
    }
}
