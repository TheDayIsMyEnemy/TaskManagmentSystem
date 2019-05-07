using TaskManagmentSystem.Core.Entities;
using TaskManagmentSystem.Core.Interfaces;

namespace TaskManagmentSystem.Infrastructure.Data
{
    public class TaskRepository : EfRepository<AppTask>, ITaskRepository
    {
        public TaskRepository(AppDbContext db) : base(db) { }


    }
}
