using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.DTOs;
using TaskManagmentSystem.Core.Entities;
using TaskManagmentSystem.Core.Interfaces;

namespace TaskManagmentSystem.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository tasks;

        public TaskService(ITaskRepository tasks)
        {
            this.tasks = tasks;
        }

        public async Task<TaskDto> GetByIdAsync(int id)
        {
            TaskDto result = null;
            AppTask task = await tasks.GetByIdAsync(id);

            return result;
        }
    }
}
