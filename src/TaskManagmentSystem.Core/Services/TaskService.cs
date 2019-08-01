using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task<int> CreateTaskAsync(string title, string description, Entities.TaskState status, TaskPriority priority, DateTime? dueDate)
        {
            AppTask task = new AppTask
            {
                Title = title,
                Description = description,
                State = status,
                Priority = priority,
                DueDate = dueDate
            };

            await tasks.CreateAsync(task);
            return task.Id;
        }

        public async Task<TaskDto> GetByIdAsync(int id)
            => mapper.Map<TaskDto>(await tasks.GetByIdAsync(id));

        public async Task<int> GetTaskCountAsync()
            => await tasks.CountAsync();

        public async Task<IEnumerable<TaskDto>> List(int page, int pageSize)
            => mapper.Map<IEnumerable<TaskDto>>(await tasks.ListAsync(page, pageSize));

        public async Task<IList<TaskDto>> SearchAsync(int page, int pageSize, string searchText)
            => mapper.Map<IList<TaskDto>>(await tasks.SearchAsync(page, pageSize, searchText));

        public async Task<IList<TaskDto>> SearchAsync(int page, int pageSize, string searchText, bool title, bool description, TaskPriority priority, TaskState state, DateTime? dueDate, DateTime? created, int? creatorId)
            => mapper.Map<IList<TaskDto>>(await tasks.SearchAsync(page, pageSize, searchText, title, description, priority, state, dueDate, created, creatorId));
    }
}
