using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TaskManagmentSystem.Core.Entities;
using TaskManagmentSystem.Core.Interfaces;
using System.Threading.Tasks;

namespace TaskManagmentSystem.Infrastructure.Data
{
    public class TaskRepository : EfRepository<AppTask>, ITaskRepository
    {
        public TaskRepository(AppDbContext db) : base(db) { }

        public async Task<IEnumerable<AppTask>> List(int page, int pageSize)
            => await db.Tasks
                .OrderByDescending(t => t.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();


    }
}
