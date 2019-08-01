using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Entities;

namespace TaskManagmentSystem.Core.Interfaces
{
    public interface ITaskRepository : IAsyncRepository<AppTask>
    {
        Task<IEnumerable<AppTask>> ListAsync(int page, int pageSize);

        Task<IList<AppTask>> SearchAsync(int page, int pageSize, string searchText);

        Task<IList<AppTask>> SearchAsync(int page,
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
