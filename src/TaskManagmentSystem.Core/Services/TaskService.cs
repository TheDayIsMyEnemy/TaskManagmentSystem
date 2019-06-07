using AutoMapper;
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
        private readonly IMapper mapper;
        private readonly ITaskRepository tasks;

        public TaskService(IMapper mapper, ITaskRepository tasks)
        {
            this.mapper = mapper;
            this.tasks = tasks;
        }

        public async Task<int> CreateTaskAsync(string title, string description, Entities.TaskStatus status, TaskPriority priority, DateTime? dueDate)
        {
            AppTask task = new AppTask
            {
                Title = title,
                Description = description,
                Status = status,
                Priority = priority,
                DueDate = dueDate
            };

            await tasks.CreateAsync(task);
            return task.Id;
        }

        public async Task<TaskDto> GetByIdAsync(int id)
        {
            AppTask task = await tasks.GetByIdAsync(id);
            return mapper.Map<TaskDto>(task);
        }
    }
}
