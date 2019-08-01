using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TaskManagmentSystem.Core.Entities;
using TaskManagmentSystem.Core.Interfaces;
using System.Threading.Tasks;
using System;

namespace TaskManagmentSystem.Infrastructure.Data
{
    public class TaskRepository : EfRepository<AppTask>, ITaskRepository
    {
        public TaskRepository(AppDbContext db) : base(db) { }

        public async Task<IEnumerable<AppTask>> ListAsync(int page, int pageSize)
            => await db.Tasks
                .OrderByDescending(t => t.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

        public async Task<IList<AppTask>> SearchAsync(int page, int pageSize, string searchText)
        {
            
            return await db.Tasks
                    .Where(t => t.Title.Contains(searchText) || t.Description.Contains(searchText))
                    .OrderByDescending(t => t.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<IList<AppTask>> SearchAsync(int page,
            int pageSize,
            string searchText,
            bool title,
            bool description,
            TaskPriority priority,
            TaskState state,
            DateTime? dueDate,
            DateTime? created,
            int? creatorId)
        {
            IQueryable<AppTask> query;

            if (title)
            {
                query = db.Tasks.Where(t => t.Title.Contains(searchText));
            }
            if (description)
            {
                query = db.Tasks.Where(t => t.Description.Contains(searchText));
            }

            query = db.Tasks.Where(t => t.Priority == priority && t.State == state);

            var result = await query.Skip((page -1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();

            return result;
        }

        //public string Title { get; set; }

        //public string Description { get; set; }

        //public TaskPriority Priority { get; set; }

        //public TaskStatus Status { get; set; }

        //public DateTime? DueDate { get; set; }

        //public DateTime Created { get; set; }

        //public string CreatorId { get; set; }
        //public User Creator { get; set; }

        //public string AssigneeId { get; set; }
        //public User Assignee { get; set; }

        //public List<CategoryTask> Categories { get; set; } = new List<CategoryTask>();
    }
}
